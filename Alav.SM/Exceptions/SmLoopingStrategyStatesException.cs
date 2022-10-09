using Alav.SM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alav.SM.Exceptions
{
    public class SmLoopingStrategyStatesException<TContextModel,TStrategyState> : Exception
        where TStrategyState : Enum
        where TContextModel : IStrategyContextModel<TStrategyState>
    {
        public SmLoopingStrategyStatesException(TContextModel context) : base($"Looping state = {context.State}. CorrelationId = {context.CorrelationId}") { }
    }
}
