﻿using Alav.DI.Attributes;
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
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Transient)]
    public class ExchangeRatesStrategy: SmBaseStrategy<SagaModel>
    {
        public override void Process(SagaModel model)
        {
            Console.WriteLine($"{nameof(ExchangeRatesStrategy)}:{nameof(ProcessAsync)}");
        }

        public override async Task ProcessAsync(SagaModel model, CancellationToken cancellationToken = default)
        {
            Process(model);
        }
    }
}
