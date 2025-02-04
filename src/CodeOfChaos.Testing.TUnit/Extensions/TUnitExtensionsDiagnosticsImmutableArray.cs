// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;

namespace CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public static class TUnitExtensionsDiagnosticsImmutableArray {
    public static InvokableValueAssertionBuilder<ImmutableArray<Diagnostic>> ContainsDiagnostic(this IValueSource<ImmutableArray<Diagnostic>> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new ContainsDiagnosticAssertCondition<ImmutableArray<Diagnostic>>(
                static diagnostics => diagnostics,
                expectedId
            ),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
}
