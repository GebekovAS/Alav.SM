using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using System;

namespace Alav.SM.TestConsole.Builders
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class MoneyTransferBuilder : SmBaseStrategyBuilder<SagaModel>
    {
        public MoneyTransferBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> BuildSubStrategies()
        {
            RootStrategy
                .AddStrategy<ExchangeRatesStrategy>()
                .AddStrategy<TransferMoneyStrategy>();
            return this;
        }
    }
}
