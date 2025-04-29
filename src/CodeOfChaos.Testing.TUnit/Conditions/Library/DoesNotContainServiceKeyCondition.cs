// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainServiceKeyCondition<TServiceKey> : BaseAssertCondition<ServiceCollection> {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a registered service \"{typeof(TServiceKey).Name}\"";
    
    protected override ValueTask<AssertionResult> GetResult(ServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(ServiceCollection)} is null");
        return actualValue.All(d => d.ServiceType != typeof(TServiceKey))
            ? AssertionResult.Passed 
            : FailWithMessage($"No service with type {typeof(TServiceKey).Name} has been registered.");
    }
}
