// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit;
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Exceptions;

namespace Tests.CodeOfChaos.Testing.TUnit;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class TUnitExtensionsServiceCollectionTests {
    [Test]
    public async Task ContainsServiceKey_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();

        // Assert
        await Assert.That(services).ContainsServiceKey<string>();
    }
    
    [Test]
    public async Task ContainsServiceKey_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();
        
        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceKey<int>());
    }
    
    [Test]
    public async Task DoesNotContainServiceKey_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();

        // Assert
        await Assert.That(services).DoesNotContainServiceKey<int>();
    }
    
    [Test]
    public async Task DoesNotContainServiceKey_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();
        
        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceKey<string>());
    }
}
