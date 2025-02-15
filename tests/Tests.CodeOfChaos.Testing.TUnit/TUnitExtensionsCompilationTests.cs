// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing;
using CodeOfChaos.Testing.TUnit;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using Tests.CodeOfChaos.Testing.TUnit.DataSources;

namespace Tests.CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public class TUnitExtensionsCompilationTests {
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

    [Test]
    public async Task AddDiagnosticAnalyzer_ShouldAssert() {
        // Arrange
        RoslynCompilationRunner runner = new RoslynCompilationRunner()
                .AddDocument("Test.cs", """
                    namespace TestProject {
                        public class TestClass {
                            public void TestMethod() {
                            }
                        }
                    }
                    """)
                .AddDiagnosticAnalyzer<SimpleDiagnosticAnalyzer>()
            ;

        // Act
        CompilationWithAnalyzers compilation = await runner.GetCompilationWithAnalyzersAsync();
        ImmutableArray<Diagnostic> diagnostics = await compilation.GetAllDiagnosticsAsync();

        // Assert
        await Assert.That(diagnostics).ContainsDiagnostic(SimpleDiagnosticAnalyzer.Descriptor.Id);
    }
}
