// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Assertions.Library;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsDiagnosticsImmutableArray {
    public static ContainsDiagnosticAssertion<ImmutableArray<Diagnostic>> ContainsDiagnostic(
        this IAssertionSource<ImmutableArray<Diagnostic>> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");
        
        return new ContainsDiagnosticAssertion<ImmutableArray<Diagnostic>>(
            source.Context,
            static diagnostics => ValueTask.FromResult(diagnostics),
            expectedId
        );
    }

    public static DoesNotContainDiagnosticAssertion<ImmutableArray<Diagnostic>> DoesNotContainDiagnostic(
        this IAssertionSource<ImmutableArray<Diagnostic>> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainDiagnostic)}({expression})");
        
        return new DoesNotContainDiagnosticAssertion<ImmutableArray<Diagnostic>>(
            source.Context,
            static diagnostics => ValueTask.FromResult(diagnostics),
            expectedId
        );
    }

    public static ContainsDiagnosticsExclusivelyAssertion<ImmutableArray<Diagnostic>> ContainsDiagnosticsExclusively(
        this IAssertionSource<ImmutableArray<Diagnostic>> source,
        string[] expectedIds,
        [CallerArgumentExpression(nameof(expectedIds))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnosticsExclusively)}({expression})");
        
        return new ContainsDiagnosticsExclusivelyAssertion<ImmutableArray<Diagnostic>>(
            source.Context,
            static diagnostics => ValueTask.FromResult(diagnostics),
            expectedIds
        );
    }
}
