using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public abstract class SmBaseStrategyContextFactory<TContextModel> : ISmStrategyContextFactory<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <inheritdoc />
        public abstract ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
