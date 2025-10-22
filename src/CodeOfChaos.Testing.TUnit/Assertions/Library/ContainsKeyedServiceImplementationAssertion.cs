// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsKeyedServiceImplementationAssertion(
    AssertionContext<IServiceCollection> context,
    Type serviceType,
    Type implementationType,
    object? key
) : Assertion<IServiceCollection>(context) {
    protected override string GetExpectation() =>
        $"to have a registered keyed service of type \"{serviceType.Name}\" implemented by \"{implementationType.Name}\" with key \"{key}\"";

    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<IServiceCollection> metadata) {
        if (metadata.Exception is {} exception) return Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));

        IServiceCollection? actualValue = metadata.Value;
        if (actualValue is null) return Task.FromResult(AssertionResult.Failed($"{nameof(IServiceCollection)} is null"));

        return Task.FromResult(
        actualValue.Any(Predicate)
            ? AssertionResult.Passed
            : AssertionResult.Failed($"No keyed service with type {serviceType.Name}, implementation {implementationType.Name}, and key {key} has been registered.")
        );
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
