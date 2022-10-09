using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    public interface ISmStrategyBuilder<TContextModel>
        where TContextModel: class
    {
        ISmStrategyBuilder<TContextModel> BuildRootStrategy();

        ISmStrategyBuilder<TContextModel> BuildSubStrategies();

        ISmStrategy<TContextModel> GetResult();
    }
}
