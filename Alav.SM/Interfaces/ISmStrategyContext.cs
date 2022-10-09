using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    public interface ISmStrategyContext<TContextModel>
        where TContextModel : class
    {
        ISmStrategyBuilder<TContextModel> GetBuilder(TContextModel context);

        ISmStrategyContext<TContextModel> Configurate(TContextModel context);

        void Process(TContextModel context);

        Task ProcessAsync(TContextModel context, CancellationToken cancellationToken);
    }
}
