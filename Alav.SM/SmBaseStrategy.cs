using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />

    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public abstract class SmBaseStrategy<TContextModel, TStrategyState> : ISmStrategy<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <inheritdoc />
        public abstract Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
