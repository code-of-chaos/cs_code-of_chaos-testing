// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Assertions.Library;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Runtime.CompilerServices;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsCompilationWithAnalyzers {
    public static ContainsDiagnosticAssertion<CompilationWithAnalyzers> ContainsDiagnostic(
        this IAssertionSource<CompilationWithAnalyzers> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");

        return new ContainsDiagnosticAssertion<CompilationWithAnalyzers>(
            source.Context,
            async static compilation => await compilation.GetAllDiagnosticsAsync(),
            expectedId
        );
    }

    public static DoesNotContainDiagnosticAssertion<CompilationWithAnalyzers> DoesNotContainDiagnostic(
        this IAssertionSource<CompilationWithAnalyzers> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");

        return new DoesNotContainDiagnosticAssertion<CompilationWithAnalyzers>(
            source.Context,
            async static compilation => await compilation.GetAllDiagnosticsAsync(),
            expectedId
        );
    }

    public static ContainsDiagnosticsExclusivelyAssertion<CompilationWithAnalyzers> ContainsDiagnosticsExclusively(
        this IAssertionSource<CompilationWithAnalyzers> source,
        string[] expectedIds,
        [CallerArgumentExpression(nameof(expectedIds))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");

        return new ContainsDiagnosticsExclusivelyAssertion<CompilationWithAnalyzers>(
            source.Context,
            async static compilation => await compilation.GetAllDiagnosticsAsync(),
            expectedIds
        );
    }
}
