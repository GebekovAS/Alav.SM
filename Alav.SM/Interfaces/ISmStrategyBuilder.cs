using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy builder
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyBuilder<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Build root (composite) strategy 
        /// </summary>
        /// <returns></returns>
        ISmStrategyBuilder<TContextModel, TStrategyState> BuildRootStrategy();

        /// <summary>
        /// Build sub strategies
        /// </summary>
        ISmStrategyBuilder<TContextModel, TStrategyState> BuildSubStrategies();

        /// <summary>
        /// Get result strategy (composite)
        /// </summary>
        ISmStrategy<TContextModel, TStrategyState> GetResult();
    }
}
