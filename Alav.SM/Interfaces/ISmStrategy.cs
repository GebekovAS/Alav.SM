using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategy<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <summary>
        /// Process strategy
        /// </summary>
        /// <param name="context">Saga model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
