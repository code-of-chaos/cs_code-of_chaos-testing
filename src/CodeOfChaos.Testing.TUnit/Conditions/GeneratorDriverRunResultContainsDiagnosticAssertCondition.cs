// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class GeneratorDriverRunResultContainsDiagnosticAssertCondition(string expectedId) : ContainsDiagnosticAssertCondition<GeneratorDriverRunResult>(expectedId) {
    protected override ImmutableArray<Diagnostic> GetDiagnostics(GeneratorDriverRunResult value) => value.Diagnostics;
}
