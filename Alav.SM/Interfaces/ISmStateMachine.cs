using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// State machine
    /// </summary>
    /// <typeparam name="TRepository">Repository</typeparam>
    /// <typeparam name="TState">State</typeparam>
    public interface ISmStateMachine<TRepository, TStrategyContextFactory, TContextModel>
        where TContextModel : IStrategyContextModel
        where TStrategyContextFactory : ISmStrategyContextFactory<TContextModel>
        where TRepository : ISmRepository<TContextModel>
    {
        /// <summary>
        /// Process saga
        /// </summary>
        /// <param name="correlationId">CorrelationId</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns></returns>
        Task ProcessAsync(Guid correlationId, CancellationToken cancellationToken = default);
    }
}
