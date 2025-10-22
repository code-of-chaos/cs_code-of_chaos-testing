// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Assertions;
using CodeOfChaos.Testing.TUnit.Assertions.Library;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsGeneratorDriverRunResult {
    public static GeneratorDriverRunResultHasSourceTextEqualToAssertion HasSourceTextEqualTo(
        this IAssertionSource<GeneratorDriverRunResult> source,
        string fileName,
        string expected,
        StringComparison stringComparison = StringComparison.Ordinal,
        bool ignoreWhiteSpace = false,
        bool withTrimming = false,
        [CallerArgumentExpression(nameof(fileName))] string? expressionFileName = null,
        [CallerArgumentExpression(nameof(expected))] string? expressionExpected = null,
        [CallerArgumentExpression(nameof(stringComparison))] string? expressionStringComparison = null,
        [CallerArgumentExpression(nameof(ignoreWhiteSpace))] string? expressionIgnoreWhiteSpace = null,
        [CallerArgumentExpression(nameof(withTrimming))] string? expressionWithTrimming = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expressionFileName},{expressionExpected},{expressionStringComparison},{expressionIgnoreWhiteSpace},{expressionWithTrimming})");

        return new GeneratorDriverRunResultHasSourceTextEqualToAssertion(
            source.Context,
            fileName,
            expected,
            stringComparison,
            ignoreWhiteSpace,
            withTrimming
        );
    }

    public static ContainsDiagnosticAssertion<GeneratorDriverRunResult> ContainsDiagnostic(
        this IAssertionSource<GeneratorDriverRunResult> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnostic)}({expression})");
        
        return new ContainsDiagnosticAssertion<GeneratorDriverRunResult>(
            source.Context,
            static runResult => ValueTask.FromResult(runResult.Diagnostics),
            expectedId
        );
    }

    public static DoesNotContainDiagnosticAssertion<GeneratorDriverRunResult> DoesNotContainDiagnostic(
        this IAssertionSource<GeneratorDriverRunResult> source,
        string expectedId,
        [CallerArgumentExpression(nameof(expectedId))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainDiagnostic)}({expression})");
        
        return new DoesNotContainDiagnosticAssertion<GeneratorDriverRunResult>(
            source.Context,
            static runResult => ValueTask.FromResult(runResult.Diagnostics),
            expectedId
        );
    }

    public static ContainsDiagnosticsExclusivelyAssertion<GeneratorDriverRunResult> ContainsDiagnosticsExclusively(
        this IAssertionSource<GeneratorDriverRunResult> source,
        string[] expectedIds,
        [CallerArgumentExpression(nameof(expectedIds))] string? expression = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsDiagnosticsExclusively)}({expression})");
        
        return new ContainsDiagnosticsExclusivelyAssertion<GeneratorDriverRunResult>(
            source.Context,
            static runResult => ValueTask.FromResult(runResult.Diagnostics),
            expectedIds
        );
    }
}
