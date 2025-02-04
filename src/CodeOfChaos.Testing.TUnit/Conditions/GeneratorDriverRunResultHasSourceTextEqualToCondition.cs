// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using TUnit.Assertions.AssertConditions;
using TUnit.Assertions.AssertConditions.String;

namespace CodeOfChaos.Testing.TUnit.Conditions;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class GeneratorDriverRunResultHasSourceTextEqualToCondition(string filename, string expected, StringComparison stringComparison, bool ignoreWhiteSpace, bool withTrimming)
    : ExpectedValueAssertCondition<GeneratorDriverRunResult, string>(expected) {
    private readonly string _expected = expected;

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => throw new NotImplementedException();
    protected async override Task<AssertionResult> GetResult(GeneratorDriverRunResult? runResult, string? expectedValue) {
        if (runResult is null) return AssertionResult.Fail("Compilation is null");
        if (expectedValue is null) return AssertionResult.Fail("Expected string is null");
        
        GeneratedSourceResult? generatedSource = runResult.Results
            .SelectMany(result => result.GeneratedSources)
            .SingleOrDefault(result => result.HintName == filename);
        
        if (generatedSource is null) return AssertionResult.Fail($"Could not find source with name '{filename}'");
        
        if (generatedSource.Value.SourceText is not {} sourceText) return AssertionResult.Fail("Source text is null");
        string sourceTextString = sourceText.ToString();
        
        // Use the TUnit Equals String so it follows the same structure
        var stringEqualsAssertCondition = new StringEqualsExpectedValueAssertCondition(_expected, stringComparison);
        if(withTrimming) stringEqualsAssertCondition.WithTrimming();
        if(ignoreWhiteSpace) stringEqualsAssertCondition.IgnoringWhitespace();

        return await stringEqualsAssertCondition.GetAssertionResult(sourceTextString, null);
    }
}
