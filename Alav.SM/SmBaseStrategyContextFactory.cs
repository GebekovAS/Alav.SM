using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyContextFactory<TContextModel> : ISmStrategyContextFactory<TContextModel>
        where TContextModel: class
    {
        public abstract ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
