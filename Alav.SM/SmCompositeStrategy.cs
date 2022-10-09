using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    public class SmCompositeStrategy<TSagaModel> : ISmCompositeStrategy<TSagaModel>
        where TSagaModel: class
    {
        private readonly IServiceProvider _serviceProvider;

        public SmCompositeStrategy(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly List<ISmStrategy<TSagaModel>> _strategies = new List<ISmStrategy<TSagaModel>>();

        public ISmCompositeStrategy<TSagaModel> AddStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TSagaModel>
        {
            _strategies.Add(_serviceProvider.GetRequiredService<TStrategy>());

            return this;
        }

        public ISmCompositeStrategy<TSagaModel> RemoveStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TSagaModel>
        {
            //ToDo: Оптимизировать поиск до O(1)
            var strategy = _strategies.FirstOrDefault(f => f.GetType() == typeof(TStrategy));
            if (strategy != null)
            {
                _strategies.Remove(strategy);
            }

            return this;
        }

        public void Process(TSagaModel sagaModel)
        {
            foreach (var strategy in _strategies)
            {
                strategy.Process(sagaModel);
            }
        }

        public async Task ProcessAsync(TSagaModel sagaModel, CancellationToken cancellationToken = default)
        {
            foreach (var strategy in _strategies)
            {
                await strategy.ProcessAsync(sagaModel);
            }
        }
    }
}
