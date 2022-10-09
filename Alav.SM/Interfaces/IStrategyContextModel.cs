using System;
using System.Collections.Generic;
using System.Text;

namespace Alav.SM.Interfaces
{
    public interface IStrategyContextModel<TState>
        where TState: Enum
    {
        Guid CorrelationId { get; set; }
        TState State { get; set; }
    }
}
