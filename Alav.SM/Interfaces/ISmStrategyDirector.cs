using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    public interface ISmStrategyDirector<TContextModel>
        where TContextModel: class
    {
        ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder);
    }
}
