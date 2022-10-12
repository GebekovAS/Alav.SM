using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Builders;
using Alav.SM.TestConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace Alav.SM.TestConsole.Context
{
    public class MoneyWithdrawStrategyContext : SmBaseStrategyContext<SagaModel>
    {
        public MoneyWithdrawStrategyContext(SmDirector<SagaModel> director,
            SmUnitOfWork<SagaModel> unitOfWork,
            IServiceProvider serviceProvider) : base(director, unitOfWork, serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> GetBuilder(SagaModel context)
        {
            var sagaObject = JsonSerializer.Deserialize<SagaObjectModel>(context.Object);

            return sagaObject.CurrencyTypeCode switch
            {
                "COIN" => ServiceProvider.GetRequiredService<CoinWithdrawBuilder>(),
                _ => throw new NotImplementedException(sagaObject.CurrencyTypeCode)
            };
        }
    }
}
