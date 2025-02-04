// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;

namespace CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsGeneratorDriverRunResult {
    public static InvokableValueAssertionBuilder<GeneratorDriverRunResult> HasSourceTextEqualTo(this IValueSource<GeneratorDriverRunResult> valueSource, string fileName, string expected,  StringComparison stringComparison = StringComparison.Ordinal, bool ignoreWhiteSpace = false, bool withTrimming = false ,
        [CallerArgumentExpression(nameof(fileName))] string doNotPopulateThisValue1 = "", [CallerArgumentExpression(nameof(expected))] string doNotPopulateThisValue2 = "", [CallerArgumentExpression(nameof(stringComparison))] string doNotPopulateThisValue3 = "", [CallerArgumentExpression(nameof(ignoreWhiteSpace))] string doNotPopulateThisValue4 = "", [CallerArgumentExpression(nameof(withTrimming))] string doNotPopulateThisValue5 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new GeneratorDriverRunResultHasSourceTextEqualToCondition(fileName, expected, stringComparison, ignoreWhiteSpace, withTrimming),
            argumentExpressions: [doNotPopulateThisValue1, doNotPopulateThisValue2, doNotPopulateThisValue3, doNotPopulateThisValue4, doNotPopulateThisValue5]
        );
    }
    
    public static InvokableValueAssertionBuilder<GeneratorDriverRunResult> ContainsDiagnostic(this IValueSource<GeneratorDriverRunResult> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new GeneratorDriverRunResultContainsDiagnosticAssertCondition(expectedId),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
    
    public static InvokableValueAssertionBuilder<GeneratorDriverRunResult> DoesNotContainDiagnostic(this IValueSource<GeneratorDriverRunResult> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new GeneratorDriverRunResultDoesNotContainDiagnosticAssertCondition(expectedId),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }

    public static InvokableValueAssertionBuilder<GeneratorDriverRunResult> ContainsDiagnosticsExclusively(this IValueSource<GeneratorDriverRunResult> valueSource, string[] expectedIds, [CallerArgumentExpression(nameof(expectedIds))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new GeneratorDriverRunResultContainsDiagnosticsExclusivelyAssertCondition(expectedIds),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
}
