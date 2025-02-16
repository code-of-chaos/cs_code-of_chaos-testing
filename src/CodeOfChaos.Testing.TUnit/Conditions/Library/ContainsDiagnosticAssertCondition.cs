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
public class ContainsDiagnosticAssertCondition<T>(Func<T, ValueTask<ImmutableArray<Diagnostic>>> getDiagnosticsAction, string expectedId) : BaseAssertCondition<T> {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a diagnostic with Id \"{expectedId}\"";

    protected override async ValueTask<AssertionResult> GetResult(T? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(T)} is null");

        ImmutableArray<Diagnostic> diagnostics = await getDiagnosticsAction(actualValue);
        if (!diagnostics.Any()) return FailWithMessage("No diagnostics");
        if (diagnostics.Any(d => d.Id == expectedId)) return AssertionResult.Passed;

        return FailWithMessage("No diagnostic with Id");
    }
}
