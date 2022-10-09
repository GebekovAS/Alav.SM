using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{

    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyContext<TContextModel> : ISmStrategyContext<TContextModel>
        where TContextModel: class
    {
        private readonly ISmStrategyDirector<TContextModel> _director;

        private ISmStrategy<TContextModel> _strategy;

        protected readonly IServiceProvider ServiceProvider;

        public SmBaseStrategyContext(ISmStrategyDirector<TContextModel> director,
            IServiceProvider serviceProvider)
        {
            _director = director;
            ServiceProvider = serviceProvider;
        }

        public abstract ISmStrategyBuilder<TContextModel> GetBuilder(TContextModel context);

        public ISmStrategyContext<TContextModel> Configurate(TContextModel context)
        {
            if (_strategy != null)
            {
                return this;
            }
            var builder = GetBuilder(context);
            _strategy = _director
                .Construct(builder)
                .GetResult();

            return this;
        }

        public virtual void Process(TContextModel context)
        {
            _strategy.Process(context);
        }

        public virtual Task ProcessAsync(TContextModel context, CancellationToken cancellationToken)
        {
            return _strategy.ProcessAsync(context, cancellationToken);
        }
    }
}
