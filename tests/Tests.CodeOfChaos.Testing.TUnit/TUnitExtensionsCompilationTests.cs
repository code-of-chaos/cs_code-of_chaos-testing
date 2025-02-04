// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit;
using Microsoft.CodeAnalysis;

namespace Tests.CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public class TUnitExtensionsCompilationTests{
    [Test]
    public async Task ContainsDiagnostic_ShouldAssert() {
        // Arrange
        var runner = new RoslynCompilationRunner();
        runner.AddDocument("Test.cs", """
            namespace TestProject;
            
            public class TestClass {
                public void TestMethod() {
                    int unusedVariable; // Unused local variable triggers a warning diagnostic
                }
            }
            """);
        
        // Act
        Compilation compilation = await runner.GetCompilationAsync();
        
        // Assert
        await Assert.That(compilation).ContainsDiagnostic("CS0168");
    }
    
    [Test]
    public async Task DoesNotContainDiagnostic_ShouldAssert() {
        // Arrange
        var runner = new RoslynCompilationRunner();
        runner.AddDocument("Test.cs", """
            namespace TestProject;

            public class TestClass {
                public void TestMethod() {
                }
            }
            """);
        
        // Act
        Compilation compilation = await runner.GetCompilationAsync();
        
        // Assert
        await Assert.That(compilation).DoesNotContainDiagnostic("CS0168");
    }
}