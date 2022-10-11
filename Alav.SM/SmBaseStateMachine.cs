using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc/>
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmBaseStateMachine<TRepository, TStrategyContextFactory, TContextModel, TStrategyState> : ISmStateMachine<TRepository, TStrategyContextFactory, TContextModel, TStrategyState>
        where TStrategyState : Enum
        where TContextModel : IStrategyContextModel<TStrategyState>
        where TStrategyContextFactory: ISmStrategyContextFactory<TContextModel, TStrategyState>
        where TRepository : ISmRepository<TContextModel, TStrategyState>
    {
        private readonly TRepository _repository;
        private readonly TStrategyContextFactory _strategyContextFactory;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmBaseStateMachine(TRepository repository, TStrategyContextFactory strategyContextFactory)
        {
            _repository = repository;
            _strategyContextFactory = strategyContextFactory;
        }

        /// <inheritdoc/>
        public async Task ProcessAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            var context = await _repository.GetStrategyContextModelAsync(correlationId, cancellationToken);
            var strategyContext = _strategyContextFactory.GetContext(context);
            var builder = strategyContext.Configurate(context);

            await builder.ProcessAsync(context);
        }
    }
}
