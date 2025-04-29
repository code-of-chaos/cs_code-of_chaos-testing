// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsKeyedServiceImplementationCondition(Type serviceType, Type implementationType, object? key)
    : BaseAssertCondition<IServiceCollection> 
{
    protected override string GetExpectation() =>
        $"to have a registered keyed service of type \"{serviceType.Name}\" implemented by \"{implementationType.Name}\" with key \"{key}\"";

    protected override ValueTask<AssertionResult> GetResult(IServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null)
            return AssertionResult.Fail($"{nameof(IServiceCollection)} is null");

        return actualValue.Any(Predicate)
            ? AssertionResult.Passed
            : FailWithMessage($"No keyed service with type {serviceType.Name}, implementation {implementationType.Name}, and key {key} has been registered.");
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