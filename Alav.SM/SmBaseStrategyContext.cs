using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public abstract class SmBaseStrategyContext<TRepository, TContextModel, TStrategyState> : ISmStrategyContext<TRepository, TContextModel, TStrategyState>
        where TRepository : SmBaseRepository<TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        private readonly ISmStrategyDirector<TRepository, TContextModel, TStrategyState> _director;

        private ISmStrategy<TContextModel, TStrategyState> _strategy;

        protected readonly IServiceProvider ServiceProvider;

        public SmBaseStrategyContext(ISmStrategyDirector<TRepository, TContextModel, TStrategyState> director,
            IServiceProvider serviceProvider)
        {
            _director = director;
            ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TRepository, TContextModel, TStrategyState> GetBuilder(TContextModel context);

        /// <inheritdoc />
        public ISmStrategyContext<TRepository, TContextModel, TStrategyState> Configurate(TContextModel context)
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

        /// <inheritdoc />
        public virtual Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default)
        {
            return _strategy.ProcessAsync(context, cancellationToken);
        }
    }
}
