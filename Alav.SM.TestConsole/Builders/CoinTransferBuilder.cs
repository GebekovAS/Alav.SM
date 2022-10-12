using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using System;

namespace Alav.SM.TestConsole.Builders
{
    public class CoinTransferBuilder : SmBaseStrategyBuilder<SagaModel>
    {
        public CoinTransferBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> BuildStrategies()
        {
            RootStrategy
                .AddStrategy<CoinExchangeRatesStrategy>(state: (int)TransferStrategyStateEnum.New, nextState: (int)TransferStrategyStateEnum.ExchangedCoinRates)
                .AddStrategy<CoinTransferStrategy>(state: (int)TransferStrategyStateEnum.ExchangedCoinRates, nextState: (int)TransferStrategyStateEnum.Completed);
            return this;
        }
    }
}
