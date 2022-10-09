using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlavSM<TSagaModel>(this IServiceCollection services)
            where TSagaModel: class
        {
            return services
                .AddSingleton<ISmStrategyDirector<TSagaModel>, SmDirector<TSagaModel>>()
                .AddSingleton<ISmCompositeStrategy<TSagaModel>, SmCompositeStrategy<TSagaModel>>();
        }
    }
}
