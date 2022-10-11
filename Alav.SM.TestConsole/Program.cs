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

            var stateMachine = services.GetService<SmBaseStateMachine<SagaRepository, StrategyContextFactory, SagaModel, SagaStateEnum>>();

            stateMachine.ProcessAsync(Guid.NewGuid());

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
