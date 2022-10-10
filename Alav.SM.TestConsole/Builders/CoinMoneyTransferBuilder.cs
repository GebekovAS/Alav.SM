using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Repositories;
using Alav.SM.TestConsole.Strategies;
using System;

namespace Alav.SM.TestConsole.Builders
{
    public class CoinMoneyTransferBuilder : SmBaseStrategyBuilder<SagaRepository, SagaModel, SagaStateEnum>
    {
        public CoinMoneyTransferBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaRepository, SagaModel, SagaStateEnum> BuildSubStrategies()
        {
            RootStrategy
                .AddStrategy<ExchangeCoinRatesStrategy>(state: SagaStateEnum.New, nextState: SagaStateEnum.InProcess)
                .AddStrategy<TransferCoinMoneyStrategy>(state: SagaStateEnum.InProcess, nextState: SagaStateEnum.Completed);
            return this;
        }
    }
}
