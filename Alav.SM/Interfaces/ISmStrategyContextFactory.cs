using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy context factory
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyContextFactory<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Get context for the strategy context data
        /// </summary>
        /// <param name="context">Strategy data context</param>
        ISmStrategyContext<TRepository, TContextModel, TStrategyState> GetContext(TContextModel context);
    }
}
