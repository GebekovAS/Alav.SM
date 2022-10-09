using Alav.DI.Extensions;
using Alav.SM.Extensions;
using Alav.SM.TestConsole.Models;
using Alav.SM.TestConsole.Strategies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alav.SM.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            var services = new ServiceCollection()
                            //.AddAlavSM<SagaModel>() //If not used Alav.DI
                            .Scan()
                            .BuildServiceProvider();

            var strategyContextFactory = services.GetService<StrategyContextFactory>();
            var saga = new SagaModel()
            {
                SagaType = Enums.SagaTypeEnum.TransferMoney,
                State = Enums.SagaStateEnum.New,
                Object = JsonSerializer.Serialize(new SagaObjectModel
                {
                    CurrencyCode = "BTC",
                    CurrencyTypeCode = "COIN"
                })
            };

            strategyContextFactory
                    .GetContext(saga)
                    .Configurate(saga)
                    .Process(saga);

            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
