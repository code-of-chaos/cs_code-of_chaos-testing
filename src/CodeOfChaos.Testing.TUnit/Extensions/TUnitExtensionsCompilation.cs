// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Assertions.Library;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsCompilation {
    public static ContainsDiagnosticAssertion<Compilation> ContainsDiagnostic(
        this IAssertionSource<Compilation> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");

        return new ContainsDiagnosticAssertion<Compilation>(
            source.Context,
            static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
            expectedId
        );
    }

    public static DoesNotContainDiagnosticAssertion<Compilation> DoesNotContainDiagnostic(
        this IAssertionSource<Compilation> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainDiagnostic)}({expression})");
        
        return new DoesNotContainDiagnosticAssertion<Compilation>(
            source.Context,
            static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
            expectedId
        );
    }

    public static ContainsDiagnosticsExclusivelyAssertion<Compilation> ContainsDiagnosticsExclusively(
        this IAssertionSource<Compilation> source,
        string[] expectedIds,
        [CallerArgumentExpression(nameof(expectedIds))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnosticsExclusively)}({expression})");
        
        return new ContainsDiagnosticsExclusivelyAssertion<Compilation>(
            source.Context,
            static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
            expectedIds
        );
    }
}
