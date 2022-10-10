using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy builder
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyBuilder<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Build root (composite) strategy 
        /// </summary>
        /// <returns></returns>
        ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> BuildRootStrategy();

        /// <summary>
        /// Build sub strategies
        /// </summary>
        ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> BuildSubStrategies();

        /// <summary>
        /// Get result strategy (composite)
        /// </summary>
        ISmStrategy<TContextModel, TStrategyState> GetResult();
    }
}
