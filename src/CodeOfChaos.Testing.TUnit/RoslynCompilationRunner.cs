// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RoslynCompilationRunner(string? name = null, LanguageVersion languageVersion = LanguageVersion.Latest) : IDisposable {
    private string Name { get; } = name ??  $"TestProject_{Guid.NewGuid()}";
    private Lazy<AdhocWorkspace> Workspace { get; } = new(() => new AdhocWorkspace());
   
    private Project? _project;
    private Project Project {
        get => _project ??= Workspace.Value.CurrentSolution
            .AddProject(Name, $"{Name}.dll", "C#")
            .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithPlatform(Platform.AnyCpu))
            .WithParseOptions(new CSharpParseOptions(languageVersion));
        set => _project = value;
    }

    private readonly ConcurrentBag<MetadataReference> _assemblyReferences = [
        // Some default assemblies
        GetMetadataReference(typeof(string).Assembly),
        GetMetadataReference(typeof(object).Assembly),
    ];
    private readonly ConcurrentBag<(string Name, StringBuilder Source)> _documents = new();
    
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    #region Add Documents
    public RoslynCompilationRunner AddDocument(string name, [LanguageInjection("CSharp")] string source) {
        _documents.Add((name, new StringBuilder(source)));
        return this;
    }
    #endregion
    #region Add Assembly references
    public RoslynCompilationRunner AddReferences(params Span<Assembly> assemblies) {
        foreach (Assembly assembly in assemblies) _assemblyReferences.Add(GetMetadataReference(assembly));
        return this;
    }

    public RoslynCompilationRunner AddReferences(params Span<Type> types) {
        foreach (Type type in types) _assemblyReferences.Add(GetMetadataReference(type));
        return this;
    }

    private static PortableExecutableReference GetMetadataReference(Assembly assembly) => MetadataReference.CreateFromFile(assembly.Location);
    private static PortableExecutableReference GetMetadataReference(Type type) => GetMetadataReference(type.Assembly);
    #endregion

    public async ValueTask<RoslynGeneratorRunner> GetGeneratorRunnerAsync() {
        Compilation compilation = await GetCompilationAsync();
        return new RoslynGeneratorRunner(languageVersion) {
            Compilation = compilation
        };
    }
    
    public async ValueTask<Compilation> GetCompilationAsync() {
        // Resolve all assemblies
        Project = _assemblyReferences.Aggregate(Project, (current, reference) => current.AddMetadataReference(reference));
        
        // Add All documents
        foreach ((string name, StringBuilder source) in _documents) {
            Project = Project.AddDocument(name, source.ToString()).Project;
        }
        
        // Compile the project
        Compilation? compilation = await Project.GetCompilationAsync();
        
        await Assert.That(compilation).IsNotNull();

        return compilation!;
    }

    public async ValueTask<CompilationWithAnalyzers> GetCompilationWithAnalyzersAsync() {
        // Resolve all assemblies
        Project = _assemblyReferences.Aggregate(Project, (current, reference) => current.AddMetadataReference(reference));
        
        // Add All documents
        foreach ((string name, StringBuilder source) in _documents) {
            Project = Project.AddDocument(name, source.ToString()).Project;
        }

        // Add Analyzers to the compilation phase
        var analyzers = Project.AnalyzerReferences
            .OfType<AnalyzerImageReference>() // Ensures we only get valid analyzers
            .SelectMany(reference => reference.GetAnalyzers(LanguageNames.CSharp))
            .ToImmutableArray();
        
        // Compile the project
        Compilation? compilation = await Project.GetCompilationAsync();
        await Assert.That(compilation).IsNotNull();
        
        return compilation!.WithAnalyzers(analyzers);
    }


    public RoslynCompilationRunner AddDiagnosticAnalyzer<T>() where T : DiagnosticAnalyzer, new() {
        IReadOnlyList<AnalyzerReference> currentAnalyzers = Project.AnalyzerReferences;
        AnalyzerReference[] newAnalyzers = [new AnalyzerImageReference([new T()])];
        
        Project = Project.WithAnalyzerReferences(currentAnalyzers.Concat(newAnalyzers));
        
        return this;
    }
    
    public void Dispose() {
        if (Workspace.IsValueCreated) {
            Workspace.Value.Dispose();
        }
        GC.SuppressFinalize(this);
    }
}
