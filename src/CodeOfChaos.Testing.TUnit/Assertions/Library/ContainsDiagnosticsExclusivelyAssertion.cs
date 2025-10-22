// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsDiagnosticsExclusivelyAssertion<T>(
    AssertionContext<T> context,
    Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction,
    string[] expectedIds
) : Assertion<T>(context) {
    private readonly HashSet<string> ExpectedValuesHashSet = expectedIds.ToHashSet();

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a compilation output with the following Ids \"{expectedIds}\"";

    protected override async Task<AssertionResult> CheckAsync(EvaluationMetadata<T> metadata) {
        if (metadata.Exception is {} exception) return AssertionResult.Failed($"threw {exception.GetType().Name}");
        
        T? actualValue = metadata.Value;
        if (actualValue is null) return AssertionResult.Failed($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any() && expectedIds.Length == 0) return AssertionResult.Passed;
        if (!diagnostics.Any()) return AssertionResult.Failed("No diagnostics");
        if (expectedIds.Length != diagnostics.Length) return AssertionResult.Failed("Wrong number of diagnostics");

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

        return AssertionResult.Failed(errorMessage);

    }
}
