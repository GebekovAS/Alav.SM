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
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class TransferMoneyStrategy : SmBaseStrategy<SagaModel>
    {
        public override void Process(SagaModel model)
        {
            Console.WriteLine($"{nameof(TransferMoneyStrategy)}:{nameof(ProcessAsync)}");
        }

        public override async Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);
        }
    }
}
