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
    public abstract class SmBaseStrategyContext<TContextModel> : ISmStrategyContext<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        private readonly ISmStrategyDirector<TContextModel> _director;

        private ISmStrategy<TContextModel> _strategy;

        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmBaseStrategyContext(SmDirector<TContextModel> director,
            SmUnitOfWork<TContextModel> unitOfWork,
            IServiceProvider serviceProvider)
        {
            _director = director;
            ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public abstract ISmStrategyBuilder<TContextModel> GetBuilder(TContextModel context);

        /// <inheritdoc />
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

        /// <inheritdoc />
        public virtual Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default)
        {
            return _strategy.ProcessAsync(context, cancellationToken);
        }
    }
}
