
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsKeyedServiceTypeAssertion(
    AssertionContext<IServiceCollection> context,
    Type serviceType,
    object? key
) : Assertion<IServiceCollection>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a registered keyed service of type \"{serviceType.Name}\" with key \"{key}\"";

    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<IServiceCollection> metadata) {
        if (metadata.Exception is {} exception) return Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));
        
        IServiceCollection? actualValue = metadata.Value;
        if (actualValue is null) return Task.FromResult(AssertionResult.Failed($"{nameof(IServiceCollection)} is null"));

        AssertionResult result = actualValue.Any(Predicate)
            ? AssertionResult.Passed
            : AssertionResult.Failed($"No keyed service with type {serviceType.Name} and key {key} has been registered.");
        
        return Task.FromResult(result);
    }

    private bool Predicate(ServiceDescriptor descriptor) {
        if (descriptor.ServiceKey == null && key == null)
            return descriptor.IsKeyedService
                && descriptor.ServiceType == serviceType;
            
        if (descriptor.ServiceKey == null || key == null) return false;
        if (!descriptor.IsKeyedService) return false;
        if (descriptor.ServiceType != serviceType) return false;
        if (descriptor.ServiceKey.Equals(key)) return true;
        if (key.Equals(descriptor.ServiceKey)) return true;
        if (descriptor.KeyedImplementationInstance?.Equals(key) ?? false) return true;
        return key.Equals(descriptor.KeyedImplementationInstance);
    }
}