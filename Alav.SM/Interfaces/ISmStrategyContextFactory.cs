using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    public interface ISmStrategyContextFactory<TContextModel>
        where TContextModel: class
    {
        ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
