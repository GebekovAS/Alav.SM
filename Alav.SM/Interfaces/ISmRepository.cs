using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Base strategy repository
    /// </summary>
    public interface ISmRepository<TContextModel>
        where TContextModel : IStrategyContextModel
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
