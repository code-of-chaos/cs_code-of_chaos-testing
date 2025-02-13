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
    : BaseAssertCondition<GeneratorDriverRunResult> {

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => "to have a source with the the expected text";
    protected override async Task<AssertionResult> GetResult(GeneratorDriverRunResult? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail("Compilation is null");

        GeneratedSourceResult? generatedSource = actualValue.Results
            .SelectMany(result => result.GeneratedSources)
            .SingleOrDefault(result => result.HintName == filename);

        if (generatedSource is null) return AssertionResult.Fail($"Could not find source with name '{filename}'");

        if (generatedSource.Value.SourceText is not {} sourceText) return AssertionResult.Fail("Source text is null");

        string sourceTextString = sourceText.ToString();

        // Use the TUnit Equals String so it follows the same structure
        var stringEqualsAssertCondition = new StringEqualsExpectedValueAssertCondition(expected, stringComparison);
        if (withTrimming) stringEqualsAssertCondition.WithTrimming();
        if (ignoreWhiteSpace) stringEqualsAssertCondition.IgnoringWhitespace();

        return await stringEqualsAssertCondition.GetAssertionResult(sourceTextString,null, assertionMetadata);
    }
}
