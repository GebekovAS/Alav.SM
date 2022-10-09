using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyContextFactory<TContextModel> : ISmStrategyContextFactory<TContextModel>
        where TContextModel: class
    {
        /// <inheritdoc />
        public abstract ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
