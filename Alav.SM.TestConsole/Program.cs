using Alav.DI.Extensions;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace Alav.SM.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var services = new ServiceCollection()
                            .Scan()
                            .BuildServiceProvider();

            var stateMachine = services.GetService<SmMachine<SagaRepository, StrategyContextFactory, SagaModel>>();

            stateMachine
                .ProcessAsync(Guid.NewGuid())
                .GetAwaiter()
                .GetResult();

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
