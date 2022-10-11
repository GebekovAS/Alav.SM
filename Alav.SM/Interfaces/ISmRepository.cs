using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Base strategy repository
    /// </summary>
    /// <typeparam name="TStrategyState">Strategy state enum</typeparam>
    public interface ISmRepository<TContextModel, TStrategyState>
        where TContextModel : IStrategyContextModel<TStrategyState>
        where TStrategyState : Enum
    {
        /// <summary>
        /// Get strategy context model
        /// </summary>
        /// <param name="correlationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TContextModel> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Save changes
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SaveAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
