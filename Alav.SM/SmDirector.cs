using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmDirector<TContextModel> : ISmStrategyDirector<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <inheritdoc />
        public ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder)
        {
            return builder
                .BuildCompositeStrategy()
                .BuildStrategies();
        }
    }
}
