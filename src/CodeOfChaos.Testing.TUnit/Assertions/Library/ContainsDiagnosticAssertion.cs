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
public class ContainsDiagnosticAssertion<T>(
    AssertionContext<T> context,
    Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction,
    string expectedId
) : Assertion<T>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a diagnostic with Id \"{expectedId}\"";

    protected override async Task<AssertionResult> CheckAsync(EvaluationMetadata<T> metadata) {
        if (metadata.Exception is {} exception) return AssertionResult.Failed($"threw {exception.GetType().Name}");
        
        T? actualValue = metadata.Value;
        if (actualValue is null) return AssertionResult.Failed($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any()) return AssertionResult.Failed("No diagnostics");
        if (diagnostics.Any(d => d.Id == expectedId)) return AssertionResult.Passed;

        return AssertionResult.Failed("No diagnostic with Id");
    }
}
