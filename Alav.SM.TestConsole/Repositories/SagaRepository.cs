using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Repositories
{
    public class SagaRepository : SmBaseRepository<SagaModel,SagaStateEnum>
    {
        public override async Task<SagaModel> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(GetStrategyContextModelAsync)}:{correlationId}");

            return new SagaModel {
                CorrelationId = correlationId,
                State = Enums.SagaStateEnum.New,
                SagaType = Enums.SagaTypeEnum.TransferMoney,
                Object = JsonSerializer.Serialize(new SagaObjectModel
                {
                    CurrencyCode = "BTC",
                    CurrencyTypeCode = "COIN"
                })
            };
        }

        public override Task SaveAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(SaveAsync)}:{context.State}");

            return Task.CompletedTask;
        }
    }
}
