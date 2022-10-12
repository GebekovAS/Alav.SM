using Alav.SM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alav.SM.Exceptions
{
    public class SmLoopingStrategyStatesException<TContextModel> : Exception
        where TContextModel : IStrategyContextModel
    {
        public SmLoopingStrategyStatesException(TContextModel context) : base($"Looping state = {context.State}. CorrelationId = {context.CorrelationId}") { }
    }
}
