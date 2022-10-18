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
    public class SmCompositeStrategy<TContextModel> : ISmCompositeStrategy<TContextModel>
        where TContextModel: IStrategyContextModel
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly SmUnitOfWork<TContextModel> _unitOfWork;

        /// <summary>
        /// .ctor
        /// </summary>
        public SmCompositeStrategy(IServiceProvider serviceProvider,
            SmUnitOfWork<TContextModel> unitOfWork)
        {
            _serviceProvider = serviceProvider;
            _unitOfWork = unitOfWork;
        }

        private readonly Dictionary<int, (ISmStrategy<TContextModel> strategy, int nextState)> _strategies = new Dictionary<int, (ISmStrategy<TContextModel> strategy, int nextState)>();

        /// <inheritdoc />
        public ISmCompositeStrategy<TContextModel> AddStrategy<TStrategy>(int state, int nextState)
            where TStrategy : ISmStrategy<TContextModel>
        {
            _strategies.Add(state, (_serviceProvider.GetRequiredService<TStrategy>(), nextState));

            return this;
        }

        /// <inheritdoc />
        public ISmCompositeStrategy<TContextModel> Remove(int state)
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

                if (currentState.Equals(item.nextState))
                {
                    throw new SmLoopingStrategyStatesException<TContextModel>(context);
                }

                context.State = item.nextState;
                currentState = context.State;

                await _unitOfWork.Repository.SaveAsync(context, cancellationToken);
            }
        }
    }
}
