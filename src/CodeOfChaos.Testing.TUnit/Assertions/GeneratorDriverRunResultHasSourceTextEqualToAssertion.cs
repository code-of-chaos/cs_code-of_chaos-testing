// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class GeneratorDriverRunResultHasSourceTextEqualToAssertion(
    AssertionContext<GeneratorDriverRunResult> context,
    string filename,
    string expected,
    StringComparison stringComparison,
    bool ignoreWhiteSpace,
    bool withTrimming
)
    : Assertion<GeneratorDriverRunResult>(context) {

    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => "to have a source with the the expected text";

    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<GeneratorDriverRunResult> metadata) {
        if (metadata.Exception is {} exception) return Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));
        
        GeneratorDriverRunResult? generatorResult = metadata.Value;

        if (generatorResult is null) return Task.FromResult(AssertionResult.Failed("Compilation is null"));

        GeneratedSourceResult? generatedSource = generatorResult.Results
            .SelectMany(result => result.GeneratedSources)
            .SingleOrDefault(result => result.HintName == filename);

        if (generatedSource is null) return Task.FromResult(AssertionResult.Failed($"Could not find source with name '{filename}'"));
        if (generatedSource.Value.SourceText is not {} sourceText) return Task.FromResult(AssertionResult.Failed("Source text is null"));

        string actualValue = sourceText.ToString();
        string expectedValue = expected;

        // Use the TUnit Equals String so it follows the same structure
        if (withTrimming) {
            actualValue = actualValue.Trim();
            expectedValue = expectedValue.Trim();
        }

        if (ignoreWhiteSpace) {
            actualValue = string.Concat(actualValue.Where(c => !char.IsWhiteSpace(c)));
            expectedValue = string.Concat(expectedValue.Where(c => !char.IsWhiteSpace(c)));
        }

        if (string.Equals(actualValue, expectedValue, stringComparison)) return Task.FromResult(AssertionResult.Passed);
        return Task.FromResult(AssertionResult.Failed($"Source text does not match"));

    }
}
