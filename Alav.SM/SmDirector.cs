using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmDirector<TContextModel, TStrategyState> : ISmStrategyDirector<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <inheritdoc />
        public ISmStrategyBuilder<TContextModel, TStrategyState> Construct(ISmStrategyBuilder<TContextModel, TStrategyState> builder)
        {
            return builder
                .BuildCompositeStrategy()
                .BuildStrategies();
        }
    }
}
