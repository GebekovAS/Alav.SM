using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Composite strategy
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmCompositeStrategy<TContextModel> : ISmStrategy<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        /// <summary>
        /// Add strategy to chain
        /// </summary>
        /// <typeparam name="TStrategy">Strategy</typeparam>
        ISmCompositeStrategy<TContextModel> AddStrategy<TStrategy>(int state, int nextState)
            where TStrategy: ISmStrategy<TContextModel>;

        /// <summary>
        /// Remove strategy
        /// </summary>
        ISmCompositeStrategy<TContextModel> Remove(int state);
    }
}
