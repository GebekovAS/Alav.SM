using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy context factory
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyContextFactory<TContextModel>
        where TContextModel: class
    {
        /// <summary>
        /// Get context for the strategy context data
        /// </summary>
        /// <param name="context">Strategy data context</param>
        ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
