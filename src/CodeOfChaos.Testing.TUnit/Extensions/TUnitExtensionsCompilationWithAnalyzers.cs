// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;

namespace CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsCompilationWithAnalyzers {
    public static InvokableValueAssertionBuilder<CompilationWithAnalyzers> ContainsDiagnostic(this IValueSource<CompilationWithAnalyzers> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new ContainsDiagnosticAssertCondition<CompilationWithAnalyzers>(
                async static compilation => await compilation.GetAllDiagnosticsAsync(), 
                expectedId
            ),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
    
    public static InvokableValueAssertionBuilder<CompilationWithAnalyzers> DoesNotContainDiagnostic(this IValueSource<CompilationWithAnalyzers> valueSource, string expectedId, [CallerArgumentExpression(nameof(expectedId))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new DoesNotContainDiagnosticAssertCondition<CompilationWithAnalyzers>(
                async static compilation => await compilation.GetAllDiagnosticsAsync(), 
                expectedId
            ),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }

    public static InvokableValueAssertionBuilder<CompilationWithAnalyzers> ContainsDiagnosticsExclusively(this IValueSource<CompilationWithAnalyzers> valueSource, string[] expectedIds, [CallerArgumentExpression(nameof(expectedIds))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            assertCondition: new ContainsDiagnosticsExclusivelyAssertCondition<CompilationWithAnalyzers>(
                async static compilation => await compilation.GetAllDiagnosticsAsync(), 
                expectedIds
            ),
            argumentExpressions: [doNotPopulateThisValue1]
        );
    }
    
}
