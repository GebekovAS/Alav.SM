using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Builders;
using Alav.SM.TestConsole.Context;
using Alav.SM.TestConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Alav.SM.TestConsole
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class StrategyContextFactory : SmBaseStrategyContextFactory<SagaModel>
    {
        private readonly IServiceProvider _serviceProvider;

        public StrategyContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override ISmStrategyContext<SagaModel> GetContext(SagaModel context)
        {
            return _serviceProvider.GetRequiredService<MoneyTransferStrategyContext>();
        }
    }
}
