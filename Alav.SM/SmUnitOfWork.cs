using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    /// <summary>
    /// Unit Of Work
    /// </summary>
    /// <typeparam name="TContextModel">Strategy context model type</typeparam>
    /// <typeparam name="TStrategyState">Strategy state enum</typeparam>
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmUnitOfWork<TContextModel, TStrategyState>
        where TStrategyState : Enum
        where TContextModel : IStrategyContextModel<TStrategyState>
    {
        /// <summary>
        /// Strategy context model repository
        /// </summary>
        public ISmRepository<TContextModel, TStrategyState> Repository { get; set; }
    }
}
