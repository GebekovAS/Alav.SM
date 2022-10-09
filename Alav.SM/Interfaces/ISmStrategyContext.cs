using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    public interface ISmStrategyContext<TSagaModel>
        where TSagaModel : class
    {
        ISmStrategyBuilder<TSagaModel> GetBuilder(TSagaModel sagaModel);

        ISmStrategyContext<TSagaModel> Configurate(TSagaModel sagaModel);

        void Process(TSagaModel sagaModel);

        Task ProcessAsync(TSagaModel sagaModel, CancellationToken cancellationToken);
    }
}
