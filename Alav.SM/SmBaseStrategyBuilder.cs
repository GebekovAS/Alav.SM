using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    public abstract class SmBaseStrategyBuilder<TSagaModel> : ISmStrategyBuilder<TSagaModel>
        where TSagaModel: class
    {
        private readonly IServiceProvider _serviceProvider;

        public SmBaseStrategyBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ISmCompositeStrategy<TSagaModel> RootStrategy;

        public ISmStrategyBuilder<TSagaModel> BuildRootStrategy() 
        {
            RootStrategy = _serviceProvider.GetRequiredService<ISmCompositeStrategy<TSagaModel>>();

            return this;
        }

        public abstract ISmStrategyBuilder<TSagaModel> BuildSubStrategies();

        public virtual ISmStrategy<TSagaModel> GetResult()
        {
            return RootStrategy;
        }
    }
}
