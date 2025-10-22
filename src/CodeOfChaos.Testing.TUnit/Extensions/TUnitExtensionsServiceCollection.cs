// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using CodeOfChaos.Testing.TUnit.Assertions.Library;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using TUnit.Assertions.Core;

namespace CodeOfChaos.Testing.TUnit;
// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
// ReSharper disable once InconsistentNaming
public static class TUnitExtensionsServiceCollection {

    #region ContainsService
    public static ContainsServiceTypeAssertion ContainsServiceType<TServiceType>(
        this IAssertionSource<IServiceCollection> source,
        [CallerArgumentExpression(nameof(source))] string? expressionSource = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsServiceType)}<{typeof(TServiceType).Name}>({expressionSource})");

        return new ContainsServiceTypeAssertion(source.Context, typeof(TServiceType));
    }

    public static ContainsServiceTypeAssertion ContainsServiceType(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsServiceType)}({expressionServiceType})");

        return new ContainsServiceTypeAssertion(source.Context, serviceType);
    }

    public static DoesNotContainServiceTypeAssertion DoesNotContainServiceType<TServiceType>(
        this IAssertionSource<IServiceCollection> source,
        [CallerArgumentExpression(nameof(source))] string? expressionSource = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainServiceType)}<{typeof(TServiceType).Name}>({expressionSource})");

        return new DoesNotContainServiceTypeAssertion(source.Context, typeof(TServiceType));
    }

    public static DoesNotContainServiceTypeAssertion DoesNotContainServiceType(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainServiceType)}({expressionServiceType})");

        return new DoesNotContainServiceTypeAssertion(source.Context, serviceType);
    }
    #endregion

    #region ContainsServiceImplementation
    public static ContainsServiceImplementationAssertion ContainsServiceImplementation<TService, TImplementation>(
        this IAssertionSource<IServiceCollection> source,
        [CallerArgumentExpression(nameof(source))] string? expressionSource = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsServiceImplementation)}<{typeof(TService).Name},{typeof(TImplementation).Name}>({expressionSource})");

        return new ContainsServiceImplementationAssertion(source.Context, typeof(TService), typeof(TImplementation));
    }

    public static ContainsServiceImplementationAssertion ContainsServiceImplementation(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        Type implementationType,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(implementationType))] string? expressionImplementationType = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsServiceImplementation)}({expressionServiceType},{expressionImplementationType})");

        return new ContainsServiceImplementationAssertion(source.Context, serviceType, implementationType);
    }

    public static DoesNotContainServiceImplementationAssertion DoesNotContainServiceImplementation<TService, TImplementation>(
        this IAssertionSource<IServiceCollection> source,
        [CallerArgumentExpression(nameof(source))] string? expressionSource = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainServiceImplementation)}<{typeof(TService).Name},{typeof(TImplementation).Name}>({expressionSource})");

        return new DoesNotContainServiceImplementationAssertion(source.Context, typeof(TService), typeof(TImplementation));
    }

    public static DoesNotContainServiceImplementationAssertion DoesNotContainServiceImplementation(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        Type implementationType,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(implementationType))] string? expressionImplementationType = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainServiceImplementation)}({expressionServiceType},{expressionImplementationType})");

        return new DoesNotContainServiceImplementationAssertion(source.Context, serviceType, implementationType);
    }
    #endregion

    #region ContainsKeyedService
    public static ContainsKeyedServiceTypeAssertion ContainsKeyedServiceType<TServiceType>(
        this IAssertionSource<IServiceCollection> source,
        object? key,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsKeyedServiceType)}<{typeof(TServiceType).Name}>({expressionKey})");

        return new ContainsKeyedServiceTypeAssertion(source.Context, typeof(TServiceType), key);
    }

    public static DoesNotContainKeyedServiceTypeAssertion DoesNotContainKeyedServiceType<TServiceType>(
        this IAssertionSource<IServiceCollection> source,
        object? key,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainKeyedServiceType)}<{typeof(TServiceType).Name}>({expressionKey})");

        return new DoesNotContainKeyedServiceTypeAssertion(source.Context, typeof(TServiceType), key);
    }
    
    public static ContainsKeyedServiceTypeAssertion ContainsKeyedServiceType(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        object? key,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsKeyedServiceType)}({expressionKey}, {expressionServiceType})");

        return new ContainsKeyedServiceTypeAssertion(source.Context, serviceType, key);
    }

    public static DoesNotContainKeyedServiceTypeAssertion DoesNotContainKeyedServiceType(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        object? key,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainKeyedServiceType)}({expressionKey}, {expressionServiceType})");

        return new DoesNotContainKeyedServiceTypeAssertion(source.Context, serviceType, key);
    }
    #endregion

    #region ContainsKeyedServiceImplementation
    public static ContainsKeyedServiceImplementationAssertion ContainsKeyedServiceImplementation<TService, TImplementation>(
        this IAssertionSource<IServiceCollection> source,
        object? key,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsKeyedServiceImplementation)}<{typeof(TService).Name},{typeof(TImplementation).Name}>({expressionKey})");

        return new ContainsKeyedServiceImplementationAssertion(source.Context, typeof(TService), typeof(TImplementation), key);
    }

    public static DoesNotContainKeyedServiceImplementationAssertion DoesNotContainKeyedServiceImplementation<TService, TImplementation>(
        this IAssertionSource<IServiceCollection> source,
        object? key,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainKeyedServiceImplementation)}<{typeof(TService).Name},{typeof(TImplementation).Name}>({expressionKey})");

        return new DoesNotContainKeyedServiceImplementationAssertion(source.Context, typeof(TService), typeof(TImplementation), key);
    }
    public static ContainsKeyedServiceImplementationAssertion ContainsKeyedServiceImplementation(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        Type implementationType,
        object? key,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(implementationType))] string? expressionImplementationType = null,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(ContainsKeyedServiceImplementation)}({expressionKey},{expressionServiceType},{expressionImplementationType})");

        return new ContainsKeyedServiceImplementationAssertion(source.Context, serviceType, implementationType, key);
    }

    public static DoesNotContainKeyedServiceImplementationAssertion DoesNotContainKeyedServiceImplementation(
        this IAssertionSource<IServiceCollection> source,
        Type serviceType,
        Type implementationType,
        object? key,
        [CallerArgumentExpression(nameof(serviceType))] string? expressionServiceType = null,
        [CallerArgumentExpression(nameof(implementationType))] string? expressionImplementationType = null,
        [CallerArgumentExpression(nameof(key))] string? expressionKey = null
    ) {
        source.Context.ExpressionBuilder.Append($".{nameof(DoesNotContainKeyedServiceImplementation)}({expressionKey},{expressionServiceType},{expressionImplementationType})");

        return new DoesNotContainKeyedServiceImplementationAssertion(source.Context, serviceType, implementationType, key);
    }
    #endregion
}
