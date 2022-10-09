using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyBuilder<TContextModel> : ISmStrategyBuilder<TContextModel>
        where TContextModel: class
    {
        private readonly IServiceProvider _serviceProvider;

        public SmBaseStrategyBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ISmCompositeStrategy<TContextModel> RootStrategy;

        /// <inheritdoc />
        public ISmStrategyBuilder<TContextModel> BuildRootStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<SmCompositeStrategy<TContextModel>>();

            return this;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TContextModel> BuildSubStrategies();

        /// <inheritdoc />
        public virtual ISmStrategy<TContextModel> GetResult()
        {
            return RootStrategy;
        }
    }
}
