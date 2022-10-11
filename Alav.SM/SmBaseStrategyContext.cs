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
    public abstract class SmBaseStrategyContext<TContextModel, TStrategyState> : ISmStrategyContext<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        private readonly ISmStrategyDirector<TContextModel, TStrategyState> _director;

        private ISmStrategy<TContextModel, TStrategyState> _strategy;

        protected readonly IServiceProvider ServiceProvider;

        public SmBaseStrategyContext(SmDirector<TContextModel, TStrategyState> director,
            SmUnitOfWork<TContextModel, TStrategyState> unitOfWork,
            IServiceProvider serviceProvider)
        {
            _director = director;
            ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TContextModel, TStrategyState> GetBuilder(TContextModel context);

        /// <inheritdoc />
        public ISmStrategyContext<TContextModel, TStrategyState> Configurate(TContextModel context)
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
