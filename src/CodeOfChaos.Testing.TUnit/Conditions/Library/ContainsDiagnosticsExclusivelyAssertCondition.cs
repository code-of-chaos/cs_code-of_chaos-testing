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
public class ContainsDiagnosticsExclusivelyAssertCondition<T>(Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction, string[] expectedIds) : BaseAssertCondition<T> {
    private readonly HashSet<string> ExpectedValuesHashSet = expectedIds.ToHashSet();

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a compilation output with the following Ids \"{expectedIds}\"";
    protected override async Task<AssertionResult> GetResult(T? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any() && expectedIds.Length == 0) return AssertionResult.Passed;
        if (!diagnostics.Any()) return FailWithMessage("No diagnostics");
        if (expectedIds.Length != diagnostics.Length) return FailWithMessage("Wrong number of diagnostics");

        HashSet<string> diagnosticsHashSet = diagnostics.Select(d => d.Id).ToHashSet();

        if (diagnosticsHashSet.SetEquals(ExpectedValuesHashSet)) return AssertionResult.Passed;

        // Find which diagnostics are missing or unexpected
        string[] missingDiagnostics = ExpectedValuesHashSet.Except(diagnosticsHashSet).ToArray();
        string[] unexpectedDiagnostics = diagnosticsHashSet.Except(ExpectedValuesHashSet).ToArray();

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
