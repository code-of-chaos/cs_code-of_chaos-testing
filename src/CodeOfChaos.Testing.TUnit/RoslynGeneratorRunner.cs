// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RoslynGeneratorRunner(LanguageVersion languageVersion = LanguageVersion.Latest) {
    public Compilation? Compilation { get; set; }
    
    public GeneratorDriverRunResult AddGenerator<TGenerator>() where TGenerator : IIncrementalGenerator, new() 
        => AddGenerator(new TGenerator()); 

    public GeneratorDriverRunResult AddGenerator(params IIncrementalGenerator[] generators) {
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generators)
            .WithUpdatedParseOptions(new CSharpParseOptions(languageVersion));
        
        if (Compilation is null) throw new ArgumentNullException(nameof(Compilation));
        
        GeneratorDriverRunResult result = driver.RunGenerators(Compilation!).GetRunResult();
        
        return result;
    }
}
