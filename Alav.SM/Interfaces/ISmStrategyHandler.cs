using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Chain of Responsibility
    /// </summary>
    /// <typeparam name="TContextModel">Saga model</typeparam>
    public interface ISmStrategyHandler<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <summary>
        /// Set successor strategy
        /// </summary>
        /// <param name="strategy">Successor strategy</param>
        /// <returns></returns>
        ISmStrategy<TContextModel> SetSuccessorStrategy(ISmStrategy<TContextModel> strategy);

        Task HandleAsync(TContextModel context, CancellationToken cancellationToken = default);

    }
}
