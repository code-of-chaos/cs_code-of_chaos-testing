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
    public static InvokableValueAssertionBuilder<ServiceCollection> ContainsServiceKey<TServiceKey>(this IValueSource<ServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new ContainsServiceKeyCondition<TServiceKey>(),
            [doNotPopulateThisValue1]
        );
    }
    
    public static InvokableValueAssertionBuilder<ServiceCollection> DoesNotContainServiceKey<TServiceKey>(this IValueSource<ServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "") {
        return valueSource.RegisterAssertion(
            new DoesNotContainServiceKeyCondition<TServiceKey>(),
            [doNotPopulateThisValue1]
        );
    }
}
