using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Composite strategy
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmCompositeStrategy<TContextModel, TStrategyState> : ISmStrategy<TContextModel, TStrategyState>
        where TStrategyState : Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Add strategy to chain
        /// </summary>
        /// <typeparam name="TStrategy">Strategy</typeparam>
        ISmCompositeStrategy<TContextModel, TStrategyState> AddStrategy<TStrategy>(TStrategyState state, TStrategyState nextState)
            where TStrategy: ISmStrategy<TContextModel, TStrategyState>;

        /// <summary>
        /// Remove strategy
        /// </summary>
        /// <typeparam name="TStrategy">Strategy</typeparam>
        ISmCompositeStrategy<TContextModel, TStrategyState> Remove(TStrategyState state);
    }
}
