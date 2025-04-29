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
    public async Task ContainsServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();

        // Assert
        await Assert.That(services).ContainsServiceType<string>();
    }
    
    [Test]
    public async Task ContainsServiceType_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();
        
        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceType<int>());
    }
    
    [Test]
    public async Task DoesNotContainServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();

        // Assert
        await Assert.That(services).DoesNotContainServiceType<int>();
    }
    
    [Test]
    public async Task DoesNotContainServiceType_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();
        
        // Act
        services.AddSingleton<string, string>();
        
        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceType<string>());
    }
}
