using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using System;

namespace Alav.SM
{
    /// <summary>
    /// Unit Of Work
    /// </summary>
    /// <typeparam name="TContextModel">Strategy context model type</typeparam>
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public class SmUnitOfWork<TContextModel>
        where TContextModel : IStrategyContextModel
    {
        /// <summary>
        /// Strategy context model repository
        /// </summary>
        public ISmRepository<TContextModel> Repository { get; set; }
    }
}
