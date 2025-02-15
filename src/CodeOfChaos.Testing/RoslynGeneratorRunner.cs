// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CodeOfChaos.Testing;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class RoslynGeneratorRunner(LanguageVersion languageVersion = LanguageVersion.Latest) {
    public required Compilation Compilation { get; init; }

    public GeneratorDriverRunResult AddGenerator(params IIncrementalGenerator[] generators) {
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generators)
            .WithUpdatedParseOptions(new CSharpParseOptions(languageVersion));
        
        return driver.RunGenerators(Compilation).GetRunResult();
    }

    #region AddGenerator overloads
    public GeneratorDriverRunResult AddGenerator<TGenerator>() where TGenerator : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10, TGenerator11>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        where TGenerator11 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10(), new TGenerator11());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10, TGenerator11, TGenerator12>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        where TGenerator11 : IIncrementalGenerator, new()
        where TGenerator12 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10(), new TGenerator11(), new TGenerator12());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10, TGenerator11, TGenerator12, TGenerator13>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        where TGenerator11 : IIncrementalGenerator, new()
        where TGenerator12 : IIncrementalGenerator, new()
        where TGenerator13 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10(), new TGenerator11(), new TGenerator12(), new TGenerator13());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10, TGenerator11, TGenerator12, TGenerator13, TGenerator14>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        where TGenerator11 : IIncrementalGenerator, new()
        where TGenerator12 : IIncrementalGenerator, new()
        where TGenerator13 : IIncrementalGenerator, new()
        where TGenerator14 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10(), new TGenerator11(), new TGenerator12(), new TGenerator13(), new TGenerator14());

    public GeneratorDriverRunResult AddGenerator<TGenerator0, TGenerator1, TGenerator2, TGenerator3, TGenerator4, TGenerator5, TGenerator6, TGenerator7, TGenerator8, TGenerator9, TGenerator10, TGenerator11, TGenerator12, TGenerator13, TGenerator14, TGenerator15>()
        where TGenerator0 : IIncrementalGenerator, new()
        where TGenerator1 : IIncrementalGenerator, new()
        where TGenerator2 : IIncrementalGenerator, new()
        where TGenerator3 : IIncrementalGenerator, new()
        where TGenerator4 : IIncrementalGenerator, new()
        where TGenerator5 : IIncrementalGenerator, new()
        where TGenerator6 : IIncrementalGenerator, new()
        where TGenerator7 : IIncrementalGenerator, new()
        where TGenerator8 : IIncrementalGenerator, new()
        where TGenerator9 : IIncrementalGenerator, new()
        where TGenerator10 : IIncrementalGenerator, new()
        where TGenerator11 : IIncrementalGenerator, new()
        where TGenerator12 : IIncrementalGenerator, new()
        where TGenerator13 : IIncrementalGenerator, new()
        where TGenerator14 : IIncrementalGenerator, new()
        where TGenerator15 : IIncrementalGenerator, new()
        => AddGenerator(new TGenerator0(), new TGenerator1(), new TGenerator2(), new TGenerator3(), new TGenerator4(), new TGenerator5(), new TGenerator6(), new TGenerator7(), new TGenerator8(), new TGenerator9(), new TGenerator10(), new TGenerator11(), new TGenerator12(), new TGenerator13(), new TGenerator14(), new TGenerator15());
    #endregion
}
