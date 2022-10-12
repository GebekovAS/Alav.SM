using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using Alav.SM.TestConsole.Models;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.TestConsole.Repositories
{
    public class SagaRepository : SmBaseRepository<SagaModel>
    {
        public override async Task<SagaModel> GetStrategyContextModelAsync(Guid correlationId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(GetStrategyContextModelAsync)}: {correlationId}");

            var randomType = (Enums.SagaTypeEnum)(((byte)correlationId.ToString()[0]) % 2);

            return new SagaModel {
                CorrelationId = correlationId,
                State = 0,
                SagaType = randomType,
                Object = JsonSerializer.Serialize(new SagaObjectModel
                {
                    CurrencyCode = "BTC",
                    CurrencyTypeCode = "COIN"
                })
            };
        }

        public override Task SaveAsync(SagaModel context, CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"{nameof(SaveAsync)}: {context.State}");

            return Task.CompletedTask;
        }
    }
}
