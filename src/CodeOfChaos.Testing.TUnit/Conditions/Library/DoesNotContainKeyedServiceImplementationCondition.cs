// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainKeyedServiceImplementationCondition(Type serviceType, Type implementationType, object? key)
    : BaseAssertCondition<IServiceCollection> 
{
    protected override string GetExpectation() =>
        $"to not have a registered keyed service of type \"{serviceType.Name}\" implemented by \"{implementationType.Name}\" with key \"{key}\"";

    protected override ValueTask<AssertionResult> GetResult(IServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null)
            return AssertionResult.Fail($"{nameof(IServiceCollection)} is null");

        return actualValue.Any(Predicate)
            ? FailWithMessage($"Found keyed service of type {serviceType.Name}, implementation {implementationType.Name} registered with key {key}")
            : AssertionResult.Passed;
    }

    private bool Predicate(ServiceDescriptor descriptor) {
        return descriptor.IsKeyedService
            && descriptor.ServiceType == serviceType
            && descriptor.KeyedImplementationType == implementationType
            && ReferenceEquals(descriptor.ServiceKey, key);
    }
}
