// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Tests.CodeOfChaos.Testing.TUnit.DataSources;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
[DiagnosticAnalyzer(LanguageNames.CSharp)]
[SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1038:Compiler extensions should be implemented in assemblies with compiler-provided references")]
#pragma warning disable RS1036
public class SimpleDiagnosticAnalyzer : DiagnosticAnalyzer {
    #pragma warning disable RS2008
    public static readonly DiagnosticDescriptor Descriptor = new(
        "ANNA02",
        "Test",
        "Test",
        "Test",
        DiagnosticSeverity.Error,
        true

    );
    #pragma warning restore RS2008

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = [Descriptor];

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    public override void Initialize(AnalysisContext context) {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(ctx => {
            ISymbol symbol = ctx.Symbol;
            ctx.ReportDiagnostic(Diagnostic.Create(Descriptor, symbol.Locations.FirstOrDefault()));
        }, SymbolKind.NamedType);
    }
}
#pragma warning restore RS1036