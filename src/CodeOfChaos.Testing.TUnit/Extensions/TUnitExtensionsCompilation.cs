// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;
using TUnit.Assertions.AssertionBuilders.Wrappers;

namespace CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsCompilation {
    public static InvokableValueAssertionBuilder<Compilation> ContainsDiagnostic(this IValueSource<Compilation> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new CompilationContainsDiagnosticAssertCondition(expectedId),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
    
    public static InvokableValueAssertionBuilder<Compilation> DoesNotContainDiagnostic(this IValueSource<Compilation> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new CompilationDoesNotContainDiagnosticAssertCondition(expectedId),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }

    public static InvokableValueAssertionBuilder<Compilation> ContainsDiagnosticsExclusively(this IValueSource<Compilation> valueSource, string[] expectedIds, [CallerArgumentExpression(nameof(expectedIds))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new CompilationContainsDiagnosticsExclusivelyAssertCondition(expectedIds),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
}
