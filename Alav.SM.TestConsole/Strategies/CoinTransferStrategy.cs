using Alav.SM.TestConsole.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class CoinTransferStrategy : SmBaseStrategy<SagaModel>
    {
        public override Task ProcessAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(CoinTransferStrategy)}: {nameof(ProcessAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
