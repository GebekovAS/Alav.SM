using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using System;

namespace Alav.SM.TestConsole.Builders
{
    public class CoinWithdrawBuilder : SmBaseStrategyBuilder<SagaModel>
    {
        public CoinWithdrawBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> BuildStrategies()
        {
            RootStrategy
                .AddStrategy<CoinWithdrawStrategy>(state: (int)WithdrawStrategyStateEnum.New, nextState: (int)WithdrawStrategyStateEnum.CoinWithdrawed);
            return this;
        }
    }
}
