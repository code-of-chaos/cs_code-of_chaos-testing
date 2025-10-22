// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit.Assertions.Library;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public class ContainsServiceImplementationAssertion(
    AssertionContext<IServiceCollection> context,
    Type serviceType,
    Type serviceImplementation
) : Assertion<IServiceCollection>(context) {
    // -----------------------------------------------------------------------------------------------------------------
    // Methods
    // -----------------------------------------------------------------------------------------------------------------
    protected override string GetExpectation() => $"to have a registered service \"{serviceType.Name}\"";
    
    protected override Task<AssertionResult> CheckAsync(EvaluationMetadata<IServiceCollection> metadata) {
        if (metadata.Exception is {} exception) return Task.FromResult(AssertionResult.Failed($"threw {exception.GetType().Name}"));
        
        IServiceCollection? actualValue = metadata.Value;
        if (actualValue is null) return Task.FromResult(AssertionResult.Failed($"{nameof(IServiceCollection)} is null"));

        AssertionResult result = actualValue.Any(d => d.ServiceType == serviceType && d.ImplementationType == serviceImplementation)
            ? AssertionResult.Passed
            : AssertionResult.Failed($"No service with type {serviceType.Name} has been registered.");
        
        return Task.FromResult(result);
    }
}
