// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CompilationDoesNotContainDiagnosticAssertCondition(string expectedId)
    : ExpectedValueAssertCondition<Compilation, string>(expectedId) {

    protected override string GetExpectation() => $"to not have a diagnostic with Id \"{ExpectedValue}\"";
    
    protected override AssertionResult GetResult(Compilation? actualValue, string? expectedValue) {
        if (actualValue is null) return AssertionResult.Fail("Compilation is null");
        if (expectedValue is null) return AssertionResult.Fail("Expected value is null");
        
        ImmutableArray<Diagnostic> diagnostics = actualValue.GetDiagnostics();

        if (diagnostics.Any(d => d.Id == expectedValue)) return FailWithMessage("Diagnostic with Id");

        return AssertionResult.Passed;
    }
}
