using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyBuilder<TContextModel, TStrategyState> : ISmStrategyBuilder<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmBaseStrategyBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ISmCompositeStrategy<TContextModel, TStrategyState> RootStrategy;

        /// <inheritdoc />
        public ISmStrategyBuilder<TContextModel, TStrategyState> BuildCompositeStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<SmCompositeStrategy<TContextModel, TStrategyState>>();

            return this;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TContextModel, TStrategyState> BuildStrategies();

        /// <inheritdoc />
        public virtual ISmStrategy<TContextModel, TStrategyState> GetResult()
        {
            return RootStrategy;
        }
    }
}
