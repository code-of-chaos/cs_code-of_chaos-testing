// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class CompilationHasSourceTextEqualToCondition(string filename, string expected, StringComparison stringComparison, bool ignoreWhiteSpace, bool withTrimming)
    : ExpectedValueAssertCondition<GeneratorDriverRunResult, string>(expected) {

    protected override string GetExpectation() => throw new NotImplementedException();
    protected override AssertionResult GetResult(GeneratorDriverRunResult? runResult, string? expectedValue) {
        if (runResult is null) return AssertionResult.Fail("Compilation is null");
        if (expectedValue is null) return AssertionResult.Fail("Expected string is null");
        
        GeneratedSourceResult? generatedSource = runResult.Results
            .SelectMany(result => result.GeneratedSources)
            .SingleOrDefault(result => result.HintName == filename);
        
        if (generatedSource is null) return AssertionResult.Fail($"Could not find source with name '{filename}'");
        
        if (generatedSource.Value.SourceText is not {} sourceText) return AssertionResult.Fail("Source text is null");
        string sourceTextString = sourceText.ToString();
        
        if (ignoreWhiteSpace) sourceTextString = string.Join(string.Empty, sourceTextString.Where(c => !char.IsWhiteSpace(c)));
        if (withTrimming) sourceTextString = sourceTextString.Trim();

        return AssertionResult
            .FailIf(!string.Equals(sourceTextString, expectedValue, stringComparison), "Source text does not match"); 
    }
}
