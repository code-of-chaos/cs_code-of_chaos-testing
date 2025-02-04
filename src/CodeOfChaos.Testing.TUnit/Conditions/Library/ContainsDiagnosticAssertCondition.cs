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
public class ContainsDiagnosticAssertCondition<T>(Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction, string expectedId): ExpectedValueAssertCondition<T, string>(expectedId) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a diagnostic with Id \"{ExpectedValue}\"";
    protected override async Task<AssertionResult> GetResult(T? actualValue, string? expectedValue) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");
        if (expectedValue is null) return AssertionResult.Fail("Expected value is null");
            
        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any()) return FailWithMessage("No diagnostics");
        if (diagnostics.Any(d => d.Id == expectedValue)) return AssertionResult.Passed;
        return FailWithMessage("No diagnostic with Id");
    }
}