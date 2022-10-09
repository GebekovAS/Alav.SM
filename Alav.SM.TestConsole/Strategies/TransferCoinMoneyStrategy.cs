using Alav.SM.TestConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.TestConsole.Strategies
{
    public class TransferCoinMoneyStrategy : SmBaseStrategy<SagaModel>
    {
        public override void Process(SagaModel model)
        {
            Console.WriteLine($"{nameof(TransferCoinMoneyStrategy)}:{nameof(ProcessAsync)}");
        }

        public override Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);

            return Task.CompletedTask;
        }
    }
}
