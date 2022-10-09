using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlavSM<TContextModel>(this IServiceCollection services)
            where TContextModel: class
        {
            return services
                .AddSingleton<ISmStrategyDirector<TContextModel>, SmDirector<TContextModel>>()
                .AddSingleton<ISmCompositeStrategy<TContextModel>, SmCompositeStrategy<TContextModel>>();
        }
    }
}
