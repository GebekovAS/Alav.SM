using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Builder director
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyDirector<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Construct builder
        /// </summary>
        /// <param name="builder">builder</param>
        ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> Construct(ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> builder);
    }
}
