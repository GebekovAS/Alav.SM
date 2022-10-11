using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmUnitOfWork<TContextModel, TStrategyState>
        where TStrategyState : Enum
        where TContextModel : IStrategyContextModel<TStrategyState>
    {
        public ISmRepository<TStrategyState> Repository { get; set; }
    }
}
