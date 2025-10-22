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
public class DoesNotContainDiagnosticAssertion<T>(
    AssertionContext<T> context,
    Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction,
    string expectedId
) : Assertion<T>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to not have a diagnostic with Id \"{expectedId}\"";
    
    protected override async Task<AssertionResult> CheckAsync(EvaluationMetadata<T> metadata) {
        if (metadata.Exception is {} exception) return AssertionResult.Failed($"threw {exception.GetType().Name}");
        
        T? actualValue = metadata.Value;
        if (actualValue is null) return AssertionResult.Failed($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        
        AssertionResult result = diagnostics.Any(d => d.Id == expectedId)
            ? AssertionResult.Failed("Diagnostic with Id")
            : AssertionResult.Passed;
        
        return result;
    }
}
