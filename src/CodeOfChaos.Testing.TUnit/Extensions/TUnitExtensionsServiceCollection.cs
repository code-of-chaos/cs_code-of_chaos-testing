// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Conditions.Library;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TUnit.Assertions.AssertConditions.Interfaces;
using TUnit.Assertions.AssertionBuilders;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsServiceCollection {
    public static InvokableValueAssertionBuilder<ServiceCollection> ContainsServiceType<TServiceType>(this IValueSource<ServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new ContainsServiceTypeCondition<TServiceType>(),
            [doNotPopulateThisValue1]
        );
    }
    
    public static InvokableValueAssertionBuilder<ServiceCollection> DoesNotContainServiceType<TServiceType>(this IValueSource<ServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new DoesNotContainServiceTypeCondition<TServiceType>(),
            [doNotPopulateThisValue1]
        );
    }
}
