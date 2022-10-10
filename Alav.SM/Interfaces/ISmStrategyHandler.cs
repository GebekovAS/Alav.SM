using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Chain of Responsibility
    /// </summary>
    /// <typeparam name="TContextModel">Saga model</typeparam>
    public interface ISmStrategyHandler<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Set successor strategy
        /// </summary>
        /// <param name="strategy">Successor strategy</param>
        /// <returns></returns>
        ISmStrategy<TContextModel, TStrategyState> SetSuccessorStrategy(ISmStrategy<TContextModel, TStrategyState> strategy);

        Task HandleAsync(TContextModel context, CancellationToken cancellationToken = default);

    }
}
