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
        ISmStrategyBuilder<TContextModel, TStrategyState> BuildCompositeStrategy();

        /// <summary>
        /// Build sub strategies
        /// </summary>
        ISmStrategyBuilder<TContextModel, TStrategyState> BuildStrategies();

        /// <summary>
        /// Get result strategy (composite)
        /// </summary>
        ISmStrategy<TContextModel, TStrategyState> GetResult();
    }
}
