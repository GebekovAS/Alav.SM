using Alav.SM.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    public abstract class SmBaseStrategyContext<TSagaModel> : ISmStrategyContext<TSagaModel>
        where TSagaModel: class
    {
        private readonly ISmStrategyDirector<TSagaModel> _director;

        private ISmStrategy<TSagaModel> _strategy;

        protected readonly IServiceProvider ServiceProvider;

        public SmBaseStrategyContext(ISmStrategyDirector<TSagaModel> director,
            IServiceProvider serviceProvider)
        {
            _director = director;
            ServiceProvider = serviceProvider;
        }

        public abstract ISmStrategyBuilder<TSagaModel> GetBuilder(TSagaModel sagaModel);

        public ISmStrategyContext<TSagaModel> Configurate(TSagaModel sagaModel)
        {
            if (_strategy != null)
            {
                return this;
            }
            var builder = GetBuilder(sagaModel);
            _strategy = _director
                .Construct(builder)
                .GetResult();

            return this;
        }

        public virtual void Process(TSagaModel sagaModel)
        {
            _strategy.Process(sagaModel);
        }

        public virtual Task ProcessAsync(TSagaModel sagaModel, CancellationToken cancellationToken)
        {
            return _strategy.ProcessAsync(sagaModel, cancellationToken);
        }
    }
}
