using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyBuilder<TRepository, TContextModel, TStrategyState> : ISmStrategyBuilder<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        private readonly IServiceProvider _serviceProvider;

        public SmBaseStrategyBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ISmCompositeStrategy<TContextModel, TStrategyState> RootStrategy;

        /// <inheritdoc />
        public ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> BuildRootStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<SmCompositeStrategy<TRepository, TContextModel, TStrategyState>>();

            return this;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> BuildSubStrategies();

        /// <inheritdoc />
        public virtual ISmStrategy<TContextModel, TStrategyState> GetResult()
        {
            return RootStrategy;
        }
    }
}
