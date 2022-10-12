using Alav.SM.TestConsole.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class CoinExchangeRatesStrategy: SmBaseStrategy<SagaModel>
    {
        public override Task ProcessAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(CoinExchangeRatesStrategy)}: {nameof(ProcessAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
