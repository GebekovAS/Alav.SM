using Alav.SM.Interfaces;
using Alav.SM.TestConsole.Enums;
using System;

namespace Alav.SM.TestConsole.Models
{
    public class SagaModel: IStrategyContextModel
    {
        public Guid CorrelationId { get; set; }
        public int State { get; set; }
        public SagaTypeEnum SagaType { get; set; }
        public string Object { get; set; }
        public string LastErrorMessage { get; set; }
    }
}
