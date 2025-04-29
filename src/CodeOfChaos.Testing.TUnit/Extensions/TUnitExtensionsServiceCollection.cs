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
    #region ContainsService
    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsServiceType<TServiceType>(this IValueSource<IServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new ContainsServiceTypeCondition(typeof(TServiceType)), [doNotPopulateThisValue1]);

    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsServiceType(this IValueSource<IServiceCollection> valueSource, Type serviceType, [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new ContainsServiceTypeCondition(serviceType), [doNotPopulateThisValue1]);

    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainServiceType<TServiceType>(this IValueSource<IServiceCollection> valueSource, [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new DoesNotContainServiceTypeCondition(typeof(TServiceType)), [doNotPopulateThisValue1]);

    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainServiceType(this IValueSource<IServiceCollection> valueSource, Type serviceType, [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new DoesNotContainServiceTypeCondition(serviceType), [doNotPopulateThisValue1]);
    #endregion

    #region ContainsServiceImplementation
    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsServiceImplementation<TService, TImplementation>(
        this IValueSource<IServiceCollection> valueSource,
        [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = ""
    )
        => valueSource.RegisterAssertion(new ContainsServiceImplementationCondition(typeof(TService), typeof(TImplementation)), [doNotPopulateThisValue1]);
    
    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsServiceImplementation(
        this IValueSource<IServiceCollection> valueSource,
        Type serviceType,
        Type implementationType,
        [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "", [CallerArgumentExpression(nameof(implementationType))] string doNotPopulateThisValue2 = ""
    )
        => valueSource.RegisterAssertion(new ContainsServiceImplementationCondition(serviceType, implementationType), [doNotPopulateThisValue1, doNotPopulateThisValue2]);

    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainServiceImplementation<TService, TImplementation>(
        this IValueSource<IServiceCollection> valueSource,
        [CallerArgumentExpression(nameof(valueSource))] string doNotPopulateThisValue1 = ""
    )
        => valueSource.RegisterAssertion(new DoesNotContainServiceImplementationCondition(typeof(TService), typeof(TImplementation)), [doNotPopulateThisValue1]);

    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainServiceImplementation(
        this IValueSource<IServiceCollection> valueSource,
        Type serviceType,
        Type implementationType,
        [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "", [CallerArgumentExpression(nameof(implementationType))] string doNotPopulateThisValue2 = ""
    )
        => valueSource.RegisterAssertion(new DoesNotContainServiceImplementationCondition(serviceType, implementationType), [doNotPopulateThisValue1, doNotPopulateThisValue2]);
    #endregion

    #region ContainsKeyedService
    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsKeyedServiceType<TServiceType>(this IValueSource<IServiceCollection> valueSource, object? key, [CallerArgumentExpression(nameof(key))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new ContainsKeyedServiceTypeCondition(typeof(TServiceType), key), [doNotPopulateThisValue1]);
    
    public static InvokableValueAssertionBuilder<IServiceCollection> ContainsKeyedServiceType(this IValueSource<IServiceCollection> valueSource, Type serviceType, object? key, [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "", [CallerArgumentExpression(nameof(key))] string doNotPopulateThisValue2 = "")
        => valueSource.RegisterAssertion(new ContainsServiceTypeCondition(serviceType), [doNotPopulateThisValue1, doNotPopulateThisValue2]);
    
    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainKeyedServiceType<TServiceType>(this IValueSource<IServiceCollection> valueSource, object? key, [CallerArgumentExpression(nameof(key))] string doNotPopulateThisValue1 = "")
        => valueSource.RegisterAssertion(new DoesNotContainKeyedServiceTypeCondition(typeof(TServiceType), key), [doNotPopulateThisValue1]);
    
    public static InvokableValueAssertionBuilder<IServiceCollection> DoesNotContainKeyedServiceType(this IValueSource<IServiceCollection> valueSource, Type serviceType, object? key, [CallerArgumentExpression(nameof(serviceType))] string doNotPopulateThisValue1 = "", [CallerArgumentExpression(nameof(key))] string doNotPopulateThisValue2 = "")
        => valueSource.RegisterAssertion(new DoesNotContainServiceTypeCondition(serviceType), [doNotPopulateThisValue1, doNotPopulateThisValue2]);
    #endregion
}
