using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Context;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.TestConsole
{
    public class StrategyContextFactory : SmBaseStrategyContextFactory<SagaRepository, SagaModel, SagaStateEnum>
    {
        private readonly IServiceProvider _serviceProvider;

        public StrategyContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override ISmStrategyContext<SagaRepository, SagaModel, SagaStateEnum> GetContext(SagaModel context)
        {
            return context.SagaType switch {
                SagaTypeEnum.TransferMoney => _serviceProvider.GetRequiredService<MoneyTransferStrategyContext>(),
                _ => throw new NotImplementedException(context.SagaType.ToString())
            };
        }
    }
}
