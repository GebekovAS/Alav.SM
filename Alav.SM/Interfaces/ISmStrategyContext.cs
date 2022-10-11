using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy context
    /// </summary>
    /// <typeparam name="TContextModel">Strategy data contex type</typeparam>
    public interface ISmStrategyContext<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Get builder
        /// </summary>
        /// <param name="context">Strategy data context</param>
        ISmStrategyBuilder<TContextModel, TStrategyState> GetBuilder(TContextModel context);
        /// <summary>
        /// Configurate builder
        /// </summary>
        /// <param name="context">Strategy data context</param>
        ISmStrategyContext<TContextModel, TStrategyState> Configurate(TContextModel context);

        /// <summary>
        /// Process strategies
        /// </summary>
        /// <param name="context">Strategy data context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default);
    }
}
