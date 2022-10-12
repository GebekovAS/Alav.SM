using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy builder
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyBuilder<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <summary>
        /// Build root (composite) strategy 
        /// </summary>
        /// <returns></returns>
        ISmStrategyBuilder<TContextModel> BuildCompositeStrategy();

        /// <summary>
        /// Build sub strategies
        /// </summary>
        ISmStrategyBuilder<TContextModel> BuildStrategies();

        /// <summary>
        /// Get result strategy (composite)
        /// </summary>
        ISmStrategy<TContextModel> GetResult();
    }
}
