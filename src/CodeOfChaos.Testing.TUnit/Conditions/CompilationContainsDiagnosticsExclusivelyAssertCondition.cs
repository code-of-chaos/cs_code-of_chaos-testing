// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;

namespace CodeOfChaos.Testing.TUnit.Conditions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CompilationContainsDiagnosticsExclusivelyAssertCondition(string[] expectedIds)
    : ContainsDiagnosticsExclusivelyAssertCondition<Compilation>(expectedIds) {

    protected override ImmutableArray<Diagnostic> GetDiagnostics(Compilation value) => value.GetDiagnostics();
}
