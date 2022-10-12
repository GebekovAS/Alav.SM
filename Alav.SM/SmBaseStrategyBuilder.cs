using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyBuilder<TContextModel> : ISmStrategyBuilder<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmBaseStrategyBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ISmCompositeStrategy<TContextModel> RootStrategy;

        /// <inheritdoc />
        public ISmStrategyBuilder<TContextModel> BuildCompositeStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<SmCompositeStrategy<TContextModel>>();

            return this;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TContextModel> BuildStrategies();

        /// <inheritdoc />
        public virtual ISmStrategy<TContextModel> GetResult()
        {
            return RootStrategy;
        }
    }
}
