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

namespace CodeOfChaos.Testing;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RoslynCompilationRunner(string? name = null, LanguageVersion languageVersion = LanguageVersion.Latest) : IDisposable {

    private readonly ConcurrentBag<MetadataReference> _assemblyReferences = [
        // Some default assemblies
        typeof(string).GetPortableExecutableReference(),
        typeof(object).GetPortableExecutableReference()
    ];
    private readonly ConcurrentBag<(string Name, StringBuilder Source)> _documents = new();

    private Project? _project;

    private string Name { get; } = name ?? $"TestProject_{Guid.NewGuid()}";
    private Lazy<AdhocWorkspace> Workspace { get; } = new(() => new AdhocWorkspace());
    private Project Project {
        get => _project ??= Workspace.Value.CurrentSolution
            .AddProject(Name, $"{Name}.dll", "C#")
            .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithPlatform(Platform.AnyCpu))
            .WithParseOptions(new CSharpParseOptions(languageVersion));
        set => _project = value;
    }

    public void Dispose() {
        if (Workspace.IsValueCreated) {
            Workspace.Value.Dispose();
        }

        GC.SuppressFinalize(this);
    }

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public RoslynCompilationRunner AddDocument(string name, [LanguageInjection("CSharp")] string source) {
        _documents.Add((name, new StringBuilder(source)));
        return this;
    }

    public async ValueTask<RoslynGeneratorRunner> GetGeneratorRunnerAsync() {
        Compilation compilation = await GetCompilationAsync();
        return new RoslynGeneratorRunner(languageVersion) {
            Compilation = compilation
        };
    }

    public async ValueTask<Compilation> GetCompilationAsync() {
        // Resolve all assemblies
        Project = _assemblyReferences.Aggregate(Project, func: (current, reference) => current.AddMetadataReference(reference));

        // Add All documents
        foreach ((string name, StringBuilder source) in _documents) {
            Project = Project.AddDocument(name, source.ToString()).Project;
        }

        // Compile the project
        Compilation? compilation = await Project.GetCompilationAsync();
        if (compilation is null) throw new InvalidOperationException("Compilation is null");

        return compilation;
    }

    public async ValueTask<CompilationWithAnalyzers> GetCompilationWithAnalyzersAsync() {
        // Resolve all assemblies
        Project = _assemblyReferences.Aggregate(Project, func: (current, reference) => current.AddMetadataReference(reference));

        // Add All documents
        foreach ((string name, StringBuilder source) in _documents) {
            Project = Project.AddDocument(name, source.ToString()).Project;
        }

        // Add Analyzers to the compilation phase
        ImmutableArray<DiagnosticAnalyzer> analyzers = Project.AnalyzerReferences
            .OfType<AnalyzerImageReference>()// Ensures we only get valid analyzers
            .SelectMany(reference => reference.GetAnalyzers(LanguageNames.CSharp))
            .ToImmutableArray();

        // Compile the project
        Compilation? compilation = await Project.GetCompilationAsync();
        if (compilation is null) throw new InvalidOperationException("Compilation is null");

        return compilation.WithAnalyzers(analyzers);
    }

    public RoslynCompilationRunner AddDiagnosticAnalyzer<T>() where T : DiagnosticAnalyzer, new() {
        IReadOnlyList<AnalyzerReference> currentAnalyzers = Project.AnalyzerReferences;
        AnalyzerReference[] newAnalyzers = [new AnalyzerImageReference([new T()])];

        Project = Project.WithAnalyzerReferences(currentAnalyzers.Concat(newAnalyzers));

        return this;
    }
    #region Add Assembly references
    public RoslynCompilationRunner AddReferences(params Span<Assembly> assemblies) {
        foreach (Assembly assembly in assemblies) _assemblyReferences.Add(assembly.GetPortableExecutableReference());
        return this;
    }

    public RoslynCompilationRunner AddReferences(params Span<Type> types) {
        foreach (Type type in types) _assemblyReferences.Add(type.GetPortableExecutableReference());
        return this;
    }
    #endregion
}
