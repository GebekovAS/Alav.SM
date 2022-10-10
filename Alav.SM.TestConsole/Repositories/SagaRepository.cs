using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Repositories
{
    public class SagaRepository : SmBaseRepository<SagaStateEnum>
    {
        public override async Task<IStrategyContextModel<SagaStateEnum>> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(GetStrategyContextModelAsync)}:{correlationId}");

            return new SagaModel {
                CorrelationId = Guid.NewGuid(),
                State = Enums.SagaStateEnum.New,
                SagaType = Enums.SagaTypeEnum.TransferMoney,
                Object = JsonSerializer.Serialize(new SagaObjectModel
                {
                    CurrencyCode = "BTC",
                    CurrencyTypeCode = "COIN"
                })
            };
        }

        public override Task SaveAsync(IStrategyContextModel<SagaStateEnum> context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(SaveAsync)}:{context.State}");

            return Task.CompletedTask;
        }
    }
}
