using Alav.DI.Attributes;
using Alav.SM.Exceptions;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class SmCompositeStrategy<TContextModel,TStrategyState> : ISmCompositeStrategy<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SmUnitOfWork<TContextModel, TStrategyState> _unitOfWork;

        public SmCompositeStrategy(IServiceProvider serviceProvider,
            SmUnitOfWork<TContextModel, TStrategyState> unitOfWork)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
        }

        private readonly Dictionary<TStrategyState, (ISmStrategy<TContextModel, TStrategyState> strategy, TStrategyState nextState)> _strategies = new Dictionary<TStrategyState, (ISmStrategy<TContextModel, TStrategyState> strategy, TStrategyState nextState)>();

        /// <inheritdoc />
        public ISmCompositeStrategy<TContextModel, TStrategyState> AddStrategy<TStrategy>(TStrategyState state, TStrategyState nextState)
            where TStrategy : ISmStrategy<TContextModel, TStrategyState>
        {
            _strategies.Add(state, (_serviceProvider.GetRequiredService<TStrategy>(), nextState));

            return this;
        }

        /// <inheritdoc />
        public ISmCompositeStrategy<TContextModel, TStrategyState> Remove(TStrategyState state)
        {
            _strategies.Remove(state);

            return this;
        }

        /// <inheritdoc />
        public async Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default)
        {
            var currentState = context.State;
            while (_strategies.ContainsKey(currentState))
            {

                var item = _strategies[context.State];
                await item.strategy.ProcessAsync(context);
                context.State = item.nextState;

                if (currentState.Equals(context.State))
                {
                    throw new SmLoopingStrategyStatesException<TContextModel, TStrategyState>(context);
                }

                await _unitOfWork.Repository.SaveAsync(context, cancellationToken);
                currentState = context.State;
            }
        }
    }
}
