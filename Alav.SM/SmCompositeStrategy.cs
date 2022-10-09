using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class SmCompositeStrategy<TContextModel> : ISmCompositeStrategy<TContextModel>
        where TContextModel: class
    {
        private readonly IServiceProvider _serviceProvider;

        public SmCompositeStrategy(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly List<ISmStrategy<TContextModel>> _strategies = new List<ISmStrategy<TContextModel>>();

        public ISmCompositeStrategy<TContextModel> AddStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TContextModel>
        {
            _strategies.Add(_serviceProvider.GetRequiredService<TStrategy>());

            return this;
        }

        public ISmCompositeStrategy<TContextModel> RemoveStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TContextModel>
        {
            //ToDo: Оптимизировать поиск до O(1)
            var strategy = _strategies.FirstOrDefault(f => f.GetType() == typeof(TStrategy));
            if (strategy != null)
            {
                _strategies.Remove(strategy);
            }

            return this;
        }

        public void Process(TContextModel context)
        {
            foreach (var strategy in _strategies)
            {
                strategy.Process(context);
            }
        }

        public async Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default)
        {
            foreach (var strategy in _strategies)
            {
                await strategy.ProcessAsync(context);
            }
        }
    }
}
