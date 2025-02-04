// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainDiagnosticAssertCondition<T>(Func<T, ImmutableArray<Diagnostic>> getDiagnosticsAction, string expectedId)
    : ExpectedValueAssertCondition<T, string>(expectedId) {

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------

    protected override string GetExpectation() => $"to not have a diagnostic with Id \"{ExpectedValue}\"";
    protected override Task<AssertionResult> GetResult(T? actualValue, string? expectedValue) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");
        if (expectedValue is null) return AssertionResult.Fail("Expected value is null");
        
        ImmutableArray<Diagnostic> diagnostics = getDiagnosticsAction(actualValue);

        if (diagnostics.Any(d => d.Id == expectedValue)) return FailWithMessage("Diagnostic with Id");

        return AssertionResult.Passed;
    }
    
}
