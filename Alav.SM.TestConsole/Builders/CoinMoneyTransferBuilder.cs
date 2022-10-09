using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using System;

namespace Alav.SM.TestConsole.Builders
{
    public class CoinMoneyTransferBuilder : SmBaseStrategyBuilder<SagaModel>
    {
        public CoinMoneyTransferBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> BuildSubStrategies()
        {
            RootStrategy
                .AddStrategy<ExchangeCoinRatesStrategy>()
                .AddStrategy<TransferCoinMoneyStrategy>();
            return this;
        }
    }
}
