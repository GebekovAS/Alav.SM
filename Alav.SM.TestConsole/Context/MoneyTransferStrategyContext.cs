using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Builders;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Alav.SM.TestConsole.Context
{
    public class MoneyTransferStrategyContext : SmBaseStrategyContext<SagaModel, SagaStateEnum>
    {
        public MoneyTransferStrategyContext(SmDirector<SagaModel, SagaStateEnum> director, IServiceProvider serviceProvider) : base(director, serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel, SagaStateEnum> GetBuilder(SagaModel context)
        {
            var sagaObject = JsonSerializer.Deserialize<SagaObjectModel>(context.Object);

            return sagaObject.CurrencyTypeCode switch {
                "COIN" => ServiceProvider.GetRequiredService<CoinMoneyTransferBuilder>(),
                _ => throw new NotImplementedException(sagaObject.CurrencyTypeCode)
                };
        }
    }
}
