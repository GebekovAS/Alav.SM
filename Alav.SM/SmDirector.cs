using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmDirector<TContextModel> : ISmStrategyDirector<TContextModel>
        where TContextModel: class
    {
        public ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder)
        {
            return builder
                .BuildRootStrategy()
                .BuildSubStrategies();
        }
    }
}
