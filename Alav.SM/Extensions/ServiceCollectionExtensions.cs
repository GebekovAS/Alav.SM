using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Extensions
{
    /// <summary>
    /// Extensions - IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Component registrar
        /// </summary>
        /// <typeparam name="TContextModel"></typeparam>
        /// <param name="services">DI service collection</param>
        public static IServiceCollection AddAlavSM<TContextModel, TStrategyState>(this IServiceCollection services)
            where TStrategyState: Enum
            where TContextModel: IStrategyContextModel<TStrategyState>
        {
            return services
                .AddSingleton<ISmStrategyDirector<TContextModel, TStrategyState>, SmDirector<TContextModel, TStrategyState>>()
                .AddSingleton<ISmCompositeStrategy<TContextModel, TStrategyState>, SmCompositeStrategy<TContextModel, TStrategyState>>();
        }
    }
}
