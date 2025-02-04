// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;

namespace Tests.CodeOfChaos.Testing.TUnit.DataSources;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class GeneratorWithDiagnostic : IIncrementalGenerator {
    public const string CodeBlock = """
        namespace CodeOfChaos.Testing.TUnit.DataSources;
        class SimpleGeneratorStuff { }
        """;
    public const string FileName = "GeneratorWithDiagnostic.cs";
    
    #pragma warning disable RS2008
    public static readonly DiagnosticDescriptor Descriptor = new(
        "ANNA01",
        "Test",
        "Test",
        "Test",
        DiagnosticSeverity.Error,
        true
    );
    #pragma warning restore RS2008
        
    public void Initialize(IncrementalGeneratorInitializationContext context) {
        context.RegisterPostInitializationOutput(ctx => {
            ctx.AddSource(FileName, CodeBlock);

        });
        
        // Quick workaround to get some sort of diagnostic in the SourceProductionContext so we can test it
        IncrementalValueProvider<Diagnostic> diagnosticProvider = context.CompilationProvider
            .Select((_, _) => Diagnostic.Create(Descriptor, Location.None));
        context.RegisterSourceOutput(diagnosticProvider, (ctx, diagnostic) => {
            ctx.ReportDiagnostic(diagnostic);
        });
    }
}
