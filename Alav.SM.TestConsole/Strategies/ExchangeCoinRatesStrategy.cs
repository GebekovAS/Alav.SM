using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Strategies
{
    public class ExchangeCoinRatesStrategy: SmBaseStrategy<SagaModel>
    {
        public override void Process(SagaModel model)
        {
            Console.WriteLine($"{nameof(ExchangeCoinRatesStrategy)}:{nameof(ProcessAsync)}");
        }

        public override Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);

            return Task.CompletedTask;
        }
    }
}
