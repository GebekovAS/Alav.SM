using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public abstract class SmBaseRepository<TContextModel, TStrategyState> : ISmRepository<TContextModel, TStrategyState>
        where TContextModel : IStrategyContextModel<TStrategyState>
        where TStrategyState : Enum
    {
        /// <inheritdoc />
        public abstract Task<TContextModel> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default);

        /// <inheritdoc />
        public abstract Task SaveAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
