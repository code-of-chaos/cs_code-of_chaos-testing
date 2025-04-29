// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.AssertConditions;

namespace CodeOfChaos.Testing.TUnit.Conditions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class DoesNotContainServiceImplementationCondition(Type serviceType, Type serviceImplementation) : BaseAssertCondition<IServiceCollection> {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a registered service \"{serviceType.Name}\"";

    protected override ValueTask<AssertionResult> GetResult(IServiceCollection? actualValue, Exception? exception, AssertionMetadata assertionMetadata) {
        if (actualValue is null) return AssertionResult.Fail($"{nameof(IServiceCollection)} is null");

        return actualValue.Any(d => d.ServiceType == serviceType && d.ImplementationType == serviceImplementation)
            ? FailWithMessage($"No service with type {serviceType.Name} has been registered.")
            : AssertionResult.Passed;
    }
}
