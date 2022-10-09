using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategy<TContextModel> where TContextModel: class
    {
        /// <summary>
        /// Process strategy
        /// </summary>
        /// <param name="context">Saga model</param>
        void Process(TContextModel context);

        /// <summary>
        /// Process strategy
        /// </summary>
        /// <param name="context">Saga model</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
