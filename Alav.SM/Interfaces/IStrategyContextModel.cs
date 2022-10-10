using System;
using System.Collections.Generic;
using System.Text;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Strategy context model 
    /// </summary>
    /// <typeparam name="TState">State enum</typeparam>
    public interface IStrategyContextModel<TState>
        where TState: Enum
    {
        Guid CorrelationId { get; set; }

        TState State { get; set; }
    }
}
