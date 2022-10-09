using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy
    /// </summary>
    /// <typeparam name="TSagaModel"></typeparam>
    public interface ISmStrategy<TSagaModel> where TSagaModel: class
    {
        /// <summary>
        /// Process strategy
        /// </summary>
        /// <param name="sagaModel">Saga model</param>
        void Process(TSagaModel sagaModel);

        /// <summary>
        /// Process strategy
        /// </summary>
        /// <param name="sagaModel">Saga model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task ProcessAsync(TSagaModel sagaModel, CancellationToken cancellationToken = default);
    }
}
