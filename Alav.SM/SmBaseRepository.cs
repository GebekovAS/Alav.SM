using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public abstract class SmBaseRepository<TStrategyState> : ISmRepository<TStrategyState>
        where TStrategyState : Enum
    {
        /// <inheritdoc />
        public abstract Task<IStrategyContextModel<TStrategyState>> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default);

        /// <inheritdoc />
        public abstract Task SaveAsync(IStrategyContextModel<TStrategyState> context, CancellationToken cancellationToken = default);
    }
}
