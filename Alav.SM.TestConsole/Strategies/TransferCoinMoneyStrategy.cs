using Alav.SM.TestConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Alav.SM.TestConsole.Enums;

namespace Alav.SM.TestConsole.Strategies
{
    public class TransferCoinMoneyStrategy : SmBaseStrategy<SagaModel, SagaStateEnum>
    {
        public override void Process(SagaModel context)
        {
            Console.WriteLine($"{nameof(TransferCoinMoneyStrategy)}: {nameof(ProcessAsync)}: {context.State}");
        }

        public override Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);

            return Task.CompletedTask;
        }
    }
}
