// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainKeyedServiceImplementationAssertion(
    AssertionContext<IServiceCollection> context,
    Type serviceType,
    Type implementationType,
    object? key
)
    : Assertion<IServiceCollection>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() =>
        $"to not have a registered keyed service of type \"{serviceType.Name}\" implemented by \"{implementationType.Name}\" with key \"{key}\"";
    
    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<IServiceCollection> metadata) {
        if (metadata.Exception is {} exception) return Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));

        IServiceCollection? actualValue = metadata.Value;
        if (actualValue is null) return Task.FromResult(AssertionResult.Failed($"{nameof(IServiceCollection)} is null"));

        AssertionResult result = actualValue.Any(Predicate)
            ? AssertionResult.Failed($"Found keyed service of type {serviceType.Name}, implementation {implementationType.Name} registered with key {key}")
            : AssertionResult.Passed;
        
        return Task.FromResult(result);
    }

    private bool Predicate(ServiceDescriptor descriptor) {
        if (descriptor.ServiceKey == null && key == null)
            return descriptor.IsKeyedService
                && descriptor.ServiceType == serviceType
                && descriptor.KeyedImplementationType == implementationType;

        if (descriptor.ServiceKey == null || key == null)
            return false;

        return descriptor.IsKeyedService
            && descriptor.ServiceType == serviceType
            && descriptor.KeyedImplementationType == implementationType
            && (descriptor.ServiceKey.Equals(key) || key.Equals(descriptor.ServiceKey));
    }
}
