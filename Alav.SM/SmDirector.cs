using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmDirector<TRepository, TContextModel, TStrategyState> : ISmStrategyDirector<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <inheritdoc />
        public ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> Construct(ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> builder)
        {
            return builder
                .BuildRootStrategy()
                .BuildSubStrategies();
        }
    }
}
