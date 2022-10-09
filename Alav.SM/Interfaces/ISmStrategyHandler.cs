using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Chain of Responsibility
    /// </summary>
    /// <typeparam name="TSagaModel">Saga model</typeparam>
    public interface ISmStrategyHandler<TSagaModel>
        where TSagaModel: class
    {
        /// <summary>
        /// Set successor strategy
        /// </summary>
        /// <param name="strategy">Successor strategy</param>
        /// <returns></returns>
        ISmStrategy<TSagaModel> SetSuccessorStrategy(ISmStrategy<TSagaModel> strategy);

        void Handle(TSagaModel sagaModel);

        Task HandleAsync(TSagaModel sagaModel, CancellationToken cancellationToken = default);

    }
}
