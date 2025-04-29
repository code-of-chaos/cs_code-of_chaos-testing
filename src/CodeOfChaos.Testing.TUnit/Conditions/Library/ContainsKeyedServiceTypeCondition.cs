
// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsKeyedServiceTypeCondition(Type serviceType, object? key) : BaseAssertCondition<IServiceCollection> {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a registered keyed service of type \"{serviceType.Name}\" with key \"{key}\"";

    protected override ValueTask<AssertionResult> GetResult(IServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null)
            return AssertionResult.Fail($"{nameof(IServiceCollection)} is null");

        return actualValue.Any(descriptor =>
            descriptor.IsKeyedService
            && descriptor.ServiceType == serviceType
            && CompareKeys(descriptor.ServiceKey, key)
        )
            ? AssertionResult.Passed
            : FailWithMessage($"No keyed service with type {serviceType.Name} and key {key} has been registered.");
    }

    private static bool CompareKeys(object? descriptorKey, object? expectedKey) {
        if (descriptorKey == null && expectedKey == null)
            return true;
            
        if (descriptorKey == null || expectedKey == null)
            return false;
            
        return descriptorKey.Equals(expectedKey) || expectedKey.Equals(descriptorKey);
    }
}