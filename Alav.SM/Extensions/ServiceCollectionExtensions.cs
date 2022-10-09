using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddAlavSM<TContextModel>(this IServiceCollection services)
            where TContextModel: class
        {
            return services
                .AddSingleton<ISmStrategyDirector<TContextModel>, SmDirector<TContextModel>>()
                .AddSingleton<ISmCompositeStrategy<TContextModel>, SmCompositeStrategy<TContextModel>>();
        }
    }
}
