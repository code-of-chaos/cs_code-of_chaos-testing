// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.CodeAnalysis;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsCompilation {
    public static InvokableValueAssertionBuilder<Compilation> ContainsDiagnostic(this IValueSource<Compilation> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new ContainsDiagnosticAssertCondition<Compilation>(
                getDiagnosticsAction: static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
                expectedId
            ),
            [doNotPopulateThisValue1]
        );
    }

    public static InvokableValueAssertionBuilder<Compilation> DoesNotContainDiagnostic(this IValueSource<Compilation> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new DoesNotContainDiagnosticAssertCondition<Compilation>(
                getDiagnosticsAction: static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
                expectedId
            ),
            [doNotPopulateThisValue1]
        );
    }

    public static InvokableValueAssertionBuilder<Compilation> ContainsDiagnosticsExclusively(this IValueSource<Compilation> valueSource, string[] expectedIds, [CallerArgumentExpression(nameof(expectedIds))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new ContainsDiagnosticsExclusivelyAssertCondition<Compilation>(
                getDiagnosticsAction: static compilation => ValueTask.FromResult(compilation.GetDiagnostics()),
                expectedIds
            ),
            [doNotPopulateThisValue1]
        );
    }
}
