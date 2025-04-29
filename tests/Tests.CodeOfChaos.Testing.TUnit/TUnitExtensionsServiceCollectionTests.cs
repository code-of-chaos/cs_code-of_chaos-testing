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
public interface IService;

public class Service : IService;

public class TUnitExtensionsServiceCollectionTests {
    #region ContainsServiceType
    [Test]
    public async Task ContainsServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.That(services).ContainsServiceType<IService>();
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsServiceType_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.That(services).ContainsServiceType(service);
    }

    [Test]
    public async Task ContainsServiceType_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceType<int>());
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsServiceType_ShouldThrowAssertion_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceType(typeof(int)));
    }

    [Test]
    public async Task DoesNotContainServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.That(services).DoesNotContainServiceType<int>();
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainServiceType_ShouldAssert_FromType(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.That(services).DoesNotContainServiceType(typeof(int));
    }

    [Test]
    public async Task DoesNotContainServiceType_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceType<IService>());
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainServiceType_ShouldThrowAssertion_FromType(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceType(service));
    }
    #endregion

    #region ContainsServiceImplementation
    [Test]
    public async Task ContainsServiceImplementation_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.That(services).ContainsServiceImplementation<IService, Service>();
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsServiceImplementation_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.That(services).ContainsServiceImplementation(service, implementation);
    }

    [Test]
    public async Task ContainsServiceImplementation_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceImplementation<int, int>()
        );
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsServiceImplementation_ShouldThrowAssertion_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsServiceImplementation(typeof(int), typeof(int))
        );
    }

    [Test]
    public async Task DoesNotContainServiceImplementation_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.That(services).DoesNotContainServiceImplementation<int, int>();
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainServiceImplementation_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.That(services).DoesNotContainServiceImplementation(typeof(int), typeof(int));
    }

    [Test]
    public async Task DoesNotContainServiceImplementation_ShouldThrowAssertion() {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton<IService, Service>();

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceImplementation<IService, Service>()
        );
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainServiceImplementation_ShouldThrowAssertion_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddSingleton(service, implementation);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainServiceImplementation(service, implementation)
        );
    }
    #endregion

}
