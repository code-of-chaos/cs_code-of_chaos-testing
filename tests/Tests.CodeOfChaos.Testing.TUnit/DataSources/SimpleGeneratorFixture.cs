// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;

namespace Tests.CodeOfChaos.Testing.TUnit.DataSources;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class SimpleGeneratorFixture : IIncrementalGenerator {
    public const string CodeBlock = """
        namespace CodeOfChaos.Testing.TUnit.DataSources;
        class SimpleGeneratorStuff { }
        """;
    public const string FileName = "SimpleGenerator.cs";

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        context.RegisterPostInitializationOutput(ctx => {
            ctx.AddSource(FileName, CodeBlock);
        });
    }
}
