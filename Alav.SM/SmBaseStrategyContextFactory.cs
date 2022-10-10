using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyContextFactory<TRepository, TContextModel, TStrategyState> : ISmStrategyContextFactory<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <inheritdoc />
        public abstract ISmStrategyContext<TRepository, TContextModel, TStrategyState> GetContext(TContextModel context);
    }
}
