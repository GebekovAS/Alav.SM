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
    public class SmMachine<TRepository, TStrategyContextFactory, TContextModel> : ISmStateMachine<TRepository, TStrategyContextFactory, TContextModel>
        where TContextModel : IStrategyContextModel
        where TStrategyContextFactory: ISmStrategyContextFactory<TContextModel>
        where TRepository : ISmRepository<TContextModel>
    {
        private readonly TRepository _repository;
        private readonly TStrategyContextFactory _strategyContextFactory;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmMachine(TRepository repository, TStrategyContextFactory strategyContextFactory, SmUnitOfWork<TContextModel> unitOfWork)
        {
            _repository = repository;
            _strategyContextFactory = strategyContextFactory;
            unitOfWork.Repository = repository;
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
