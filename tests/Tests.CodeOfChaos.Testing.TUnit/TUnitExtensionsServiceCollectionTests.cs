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

    #region ContainsKeyedService
    [Test]
    public async Task ContainsKeyedServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.That(services).ContainsKeyedServiceType<IService>(key);
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsKeyedServiceType_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, implementation, key);

        // Assert
        await Assert.That(services).ContainsKeyedServiceType(service, key);
    }

    [Test]
    public async Task ContainsKeyedServiceType_ShouldThrowAssertion_WhenServiceNotFound() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsKeyedServiceType<int>(key)
        );
    }

    [Test]
    public async Task ContainsKeyedServiceType_ShouldThrowAssertion_WhenKeyNotFound() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";
        const string wrongKey = "wrong-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsKeyedServiceType<IService>(wrongKey)
        );
    }

    [Test]
    public async Task DoesNotContainKeyedServiceType_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.That(services).DoesNotContainKeyedServiceType<int>(key);
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainKeyedServiceType_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, implementation, key);

        // Assert
        await Assert.That(services).DoesNotContainKeyedServiceType(typeof(int), key);
    }

    [Test]
    public async Task DoesNotContainKeyedServiceType_ShouldThrowAssertion_WhenServiceExists() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainKeyedServiceType<IService>(key)
        );
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainKeyedServiceType_ShouldThrowAssertion_FromTypes_WhenServiceExists(
        Type service, Type implementation
    ) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, implementation, key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainKeyedServiceType(service, key));
    }
    #endregion

    #region ContainsKeyedServiceImplementation
    [Test]
    public async Task ContainsKeyedServiceImplementation_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.That(services).ContainsKeyedServiceImplementation<IService, Service>(key);
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task ContainsKeyedServiceImplementation_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, key, implementation);

        // Assert
        await Assert.That(services).ContainsKeyedServiceImplementation(service, implementation, key);
    }

    [Test]
    public async Task ContainsKeyedServiceImplementation_ShouldThrowAssertion_WhenServiceNotFound() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsKeyedServiceImplementation<int, int>(key)
        );
    }

    [Test]
    public async Task ContainsKeyedServiceImplementation_ShouldThrowAssertion_WhenKeyNotFound() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";
        const string wrongKey = "wrong-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsKeyedServiceImplementation<IService, Service>(wrongKey)
        );
    }

    [Test]
    public async Task ContainsKeyedServiceImplementation_ShouldThrowAssertion_WhenWrongImplementation() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).ContainsKeyedServiceImplementation<IService, IService>(key)
        );
    }
    #endregion

    #region DoesNotContainKeyedServiceImplementation
    [Test]
    public async Task DoesNotContainKeyedServiceImplementation_ShouldAssert() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.That(services).DoesNotContainKeyedServiceImplementation<int, int>(key);
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainKeyedServiceImplementation_ShouldAssert_FromTypes(Type service, Type implementation) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, implementation, key);

        // Assert
        await Assert.That(services).DoesNotContainKeyedServiceImplementation(typeof(int), typeof(int), key);
    }

    [Test]
    public async Task DoesNotContainKeyedServiceImplementation_ShouldThrowAssertion_WhenFound() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainKeyedServiceImplementation<IService, Service>(key)
        );
    }

    [Test]
    [Arguments(typeof(IService), typeof(Service))]
    public async Task DoesNotContainKeyedServiceImplementation_ShouldThrowAssertion_FromTypes_WhenFound(
        Type service, Type implementation
    ) {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";

        // Act
        services.AddKeyedSingleton(service, key, implementation);

        // Assert
        await Assert.ThrowsAsync<AssertionException>(async () => await Assert.That(services).DoesNotContainKeyedServiceImplementation(service, implementation, key)
        );
    }

    [Test]
    public async Task DoesNotContainKeyedServiceImplementation_ShouldAssert_WhenDifferentKey() {
        // Arrange
        var services = new ServiceCollection();
        const string key = "test-key";
        const string differentKey = "different-key";

        // Act
        services.AddKeyedSingleton<IService, Service>(key);

        // Assert
        await Assert.That(services).DoesNotContainKeyedServiceImplementation<IService, Service>(differentKey);
    }
    #endregion

}
