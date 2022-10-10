using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Builders;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace Alav.SM.TestConsole.Context
{
    public class MoneyTransferStrategyContext : SmBaseStrategyContext<SagaRepository, SagaModel, SagaStateEnum>
    {
        public MoneyTransferStrategyContext(SmDirector<SagaRepository, SagaModel, SagaStateEnum> director, IServiceProvider serviceProvider) : base(director, serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaRepository, SagaModel, SagaStateEnum> GetBuilder(SagaModel context)
        {
            var sagaObject = JsonSerializer.Deserialize<SagaObjectModel>(context.Object);

            return sagaObject.CurrencyTypeCode switch {
                "COIN" => ServiceProvider.GetRequiredService<CoinMoneyTransferBuilder>(),
                _ => throw new NotImplementedException(sagaObject.CurrencyTypeCode)
            };
        }
    }
}
