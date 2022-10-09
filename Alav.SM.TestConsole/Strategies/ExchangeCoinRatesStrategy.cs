using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class ExchangeCoinRatesStrategy: SmBaseStrategy<SagaModel, SagaStateEnum>
    {
        public override Task ProcessAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(ExchangeCoinRatesStrategy)}: {nameof(ProcessAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
