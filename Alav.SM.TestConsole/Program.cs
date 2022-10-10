using Alav.DI.Extensions;
using Alav.SM.TestConsole.Models;
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

            var strategyContextFactory = services.GetService<StrategyContextFactory>();
            var saga = new SagaModel()
            {
                CorrelationId = Guid.NewGuid(),
                State = Enums.SagaStateEnum.New,
                SagaType = Enums.SagaTypeEnum.TransferMoney,
                Object = JsonSerializer.Serialize(new SagaObjectModel
                {
                    CurrencyCode = "BTC",
                    CurrencyTypeCode = "COIN"
                })
            };

            strategyContextFactory
                    .GetContext(saga)
                    .Configurate(saga)
                    .ProcessAsync(saga);

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
