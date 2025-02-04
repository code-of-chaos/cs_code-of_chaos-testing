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
public class CompilationContainsDiagnosticAssertCondition(string expectedId) : ContainsDiagnosticAssertCondition<Compilation>(expectedId) {
    protected override ImmutableArray<Diagnostic> GetDiagnostics(Compilation value) => value.GetDiagnostics();
}
