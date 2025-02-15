// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing;
using CodeOfChaos.Testing.TUnit;
using Microsoft.CodeAnalysis;
using Tests.CodeOfChaos.Testing.TUnit.DataSources;

namespace Tests.CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
[ClassDataSource<SimpleGeneratorFixture, GeneratorWithDiagnostic>]
public class UnitExtensionsGeneratorDriverRunResultTests(SimpleGeneratorFixture generatorFixture, GeneratorWithDiagnostic generatorWithDiagnostic) {
    [Test]
    public async Task HasSourceTextEqualTo_ShouldAssert() {
        // Arrange
        RoslynGeneratorRunner runner = await new RoslynCompilationRunner().GetGeneratorRunnerAsync();
        GeneratorDriverRunResult runResult = runner.AddGenerator(generatorFixture);

        // Act & Assert
        await Assert.That(runResult).HasSourceTextEqualTo(SimpleGeneratorFixture.FileName, SimpleGeneratorFixture.CodeBlock);
    }

    [Test]
    public async Task HasDiagnostic_ShouldAssert() {
        // Arrange
        RoslynGeneratorRunner runner = await new RoslynCompilationRunner().GetGeneratorRunnerAsync();
        GeneratorDriverRunResult runResult = runner.AddGenerator(generatorFixture, generatorWithDiagnostic);

        // Act & Assert
        await Assert.That(runResult)
            .HasSourceTextEqualTo(SimpleGeneratorFixture.FileName, SimpleGeneratorFixture.CodeBlock)
            .And.HasSourceTextEqualTo(GeneratorWithDiagnostic.FileName, GeneratorWithDiagnostic.CodeBlock)
            .And.ContainsDiagnostic(GeneratorWithDiagnostic.Descriptor.Id);
    }
}
