using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Chain of Responsibility
    /// </summary>
    /// <typeparam name="TContextModel">Saga model</typeparam>
    public interface ISmStrategyHandler<TContextModel>
        where TContextModel: class
    {
        /// <summary>
        /// Set successor strategy
        /// </summary>
        /// <param name="strategy">Successor strategy</param>
        /// <returns></returns>
        ISmStrategy<TContextModel> SetSuccessorStrategy(ISmStrategy<TContextModel> strategy);

        void Handle(TContextModel context);

        Task HandleAsync(TContextModel context, CancellationToken cancellationToken = default);

    }
}
