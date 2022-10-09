using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy builder
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyBuilder<TContextModel>
        where TContextModel: class
    {
        /// <summary>
        /// Build root (composite) strategy 
        /// </summary>
        /// <returns></returns>
        ISmStrategyBuilder<TContextModel> BuildRootStrategy();

        /// <summary>
        /// Build sub strategies
        /// </summary>
        ISmStrategyBuilder<TContextModel> BuildSubStrategies();

        /// <summary>
        /// Get result strategy (composite)
        /// </summary>
        ISmStrategy<TContextModel> GetResult();
    }
}
