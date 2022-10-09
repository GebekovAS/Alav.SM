using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
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

        public ISmStrategyBuilder<TContextModel> BuildRootStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<SmCompositeStrategy<TContextModel>>();

            return this;
        }

        public abstract ISmStrategyBuilder<TContextModel> BuildSubStrategies();

        public virtual ISmStrategy<TContextModel> GetResult()
        {
            return RootStrategy;
        }
    }
}
