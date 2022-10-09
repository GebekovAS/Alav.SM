using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Builders;
using Alav.SM.TestConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alav.SM.TestConsole.Context
{

    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class MoneyTransferStrategyContext : SmBaseStrategyContext<SagaModel>
    {
        public MoneyTransferStrategyContext(ISmStrategyDirector<SagaModel> director, IServiceProvider serviceProvider) : base(director, serviceProvider)
        { }

        public override ISmStrategyBuilder<SagaModel> GetBuilder(SagaModel sagaModel)
        {
            return ServiceProvider.GetRequiredService<MoneyTransferBuilder>();
        }
    }
}
