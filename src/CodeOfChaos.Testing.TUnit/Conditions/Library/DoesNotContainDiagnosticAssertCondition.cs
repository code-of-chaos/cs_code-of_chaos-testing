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
public class DoesNotContainDiagnosticAssertCondition<T>(Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction, string expectedId) : BaseAssertCondition<T> {

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------

    protected override string GetExpectation() => $"to not have a diagnostic with Id \"{expectedId}\"";
    protected override async Task<AssertionResult> GetResult(T? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);

        return diagnostics.Any(d => d.Id == expectedId)
            ? FailWithMessage("Diagnostic with Id")
            : AssertionResult.Passed;
    }
}
