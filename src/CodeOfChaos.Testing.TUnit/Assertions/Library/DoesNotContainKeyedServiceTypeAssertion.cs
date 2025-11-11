// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainKeyedServiceTypeAssertion(
    AssertionContext<IServiceCollection> context,
    Type serviceType,
    object? key
) : Assertion<IServiceCollection>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to not have a registered keyed service of type \"{serviceType.Name}\" with key \"{key}\"";
    
    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<IServiceCollection> metadata) {
        if (metadata.Exception is {} exception) Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));

        IServiceCollection? actualValue = metadata.Value;
        if (actualValue is null)
            return Task.FromResult(AssertionResult.Failed($"{nameof(IServiceCollection)} is null"));

        AssertionResult result = actualValue.Any(Predicate)
            ? AssertionResult.Failed($"Found service of type {serviceType.Name} registered with key {key}")
            : AssertionResult.Passed;

        return Task.FromResult(result);
    }

    private bool Predicate(ServiceDescriptor descriptor) {
        if (key == null) return !descriptor.IsKeyedService && descriptor.ServiceType == serviceType;
        if (!descriptor.IsKeyedService) return false;

        return descriptor.ServiceType == serviceType 
            && descriptor.ServiceKey != null 
            && (descriptor.ServiceKey.Equals(key) || key.Equals(descriptor.ServiceKey));
    }
}
