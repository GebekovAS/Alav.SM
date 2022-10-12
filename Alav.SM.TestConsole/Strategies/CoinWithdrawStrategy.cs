using Alav.SM.TestConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class CoinWithdrawStrategy : SmBaseStrategy<SagaModel>
    {
        public override Task ProcessAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(CoinWithdrawStrategy)}: {nameof(ProcessAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
