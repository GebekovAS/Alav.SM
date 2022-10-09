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
        public override Task ProcessAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(TransferCoinMoneyStrategy)}: {nameof(ProcessAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
