using Alav.DI.Extensions;
using Alav.SM.Extensions;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var services = new ServiceCollection()
                            .AddAlavSM<SagaModel>()
                            .Scan<Program>()
                            .BuildServiceProvider();

            var strategyContextFactory = services.GetService<StrategyContextFactory>();
            var saga = new SagaModel();
            strategyContextFactory
                    .GetContext(saga)
                    .Configurate(saga)
                    .Process(saga);

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
