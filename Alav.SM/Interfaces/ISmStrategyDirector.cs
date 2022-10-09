using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Builder director
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyDirector<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Construct builder
        /// </summary>
        /// <param name="builder">builder</param>
        ISmStrategyBuilder<TContextModel, TStrategyState> Construct(ISmStrategyBuilder<TContextModel, TStrategyState> builder);
    }
}
