
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainKeyedServiceTypeCondition(Type serviceType, object? key) : BaseAssertCondition<IServiceCollection> {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to not have a registered keyed service of type \"{serviceType.Name}\" with key \"{key}\"";

    protected override ValueTask<AssertionResult> GetResult(IServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null)
            return AssertionResult.Fail($"{nameof(IServiceCollection)} is null");

        return actualValue.Any(Predicate)
            ? FailWithMessage($"Found service of type {serviceType.Name} registered with key {key}")
            : AssertionResult.Passed;
    }

    private bool Predicate(ServiceDescriptor descriptor) {
        if (descriptor.ServiceKey == null && key == null)
            return descriptor.IsKeyedService
                && descriptor.ServiceType == serviceType;
            
        if (descriptor.ServiceKey == null || key == null)
            return false;
        
        return descriptor.IsKeyedService
            && descriptor.ServiceType == serviceType
            && (descriptor.ServiceKey.Equals(key) || key.Equals(descriptor.ServiceKey));
    }
}