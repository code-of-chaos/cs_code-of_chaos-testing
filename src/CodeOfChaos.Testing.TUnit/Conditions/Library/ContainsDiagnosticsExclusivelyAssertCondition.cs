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
public class ContainsDiagnosticsExclusivelyAssertCondition<T>(Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction, string[] expectedIds)
    : ExpectedValueAssertCondition<T, string[]>(expectedIds) {

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a compilation output with the following Ids \"{ExpectedValue}\"";
    protected override async Task<AssertionResult> GetResult(T? actualValue, string[]? expectedValues) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");
        if (expectedValues is null) return AssertionResult.Fail("Expected value is null");
        
        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any() && expectedValues.Length == 0) return AssertionResult.Passed;
        if (!diagnostics.Any()) return FailWithMessage("No diagnostics");
        if (expectedValues.Length != diagnostics.Length) return FailWithMessage("Wrong number of diagnostics");
        
        HashSet<string> diagnosticsHashSet = diagnostics.Select(d => d.Id).ToHashSet();
        HashSet<string> expectedValuesHashSet = expectedValues.ToHashSet();
        
        if (diagnosticsHashSet.SetEquals(expectedValuesHashSet)) return AssertionResult.Passed;

        // Find which diagnostics are missing or unexpected
        string[] missingDiagnostics = expectedValuesHashSet.Except(diagnosticsHashSet).ToArray();
        string[] unexpectedDiagnostics = diagnosticsHashSet.Except(expectedValuesHashSet).ToArray();
            
        string errorMessage = "Diagnostics do not match:";
            
        if (missingDiagnostics.Length != 0) {
            errorMessage += $"\n  - Missing diagnostics: {string.Join(", ", missingDiagnostics)}";
        }
        
        if (unexpectedDiagnostics.Length != 0) {
            errorMessage += $"\n  - Unexpected diagnostics: {string.Join(", ", unexpectedDiagnostics)}";
        }
            
        return AssertionResult.Fail(errorMessage);

    }
}
