using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class ExchangeCoinRatesStrategy: SmBaseStrategy<SagaModel, SagaStateEnum>
    {
        public override void Process(SagaModel context)
        {
            Console.WriteLine($"{nameof(ExchangeCoinRatesStrategy)}: {nameof(ProcessAsync)}: {context.State}");
        }

        public override Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);

            return Task.CompletedTask;
        }
    }
}
