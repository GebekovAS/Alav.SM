using System;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy context model 
    /// </summary>
    public interface IStrategyContextModel
    {
        Guid CorrelationId { get; set; }

        int State { get; set; }
    }
}
