using Alav.SM.TestConsole.Enums;

namespace Alav.SM.TestConsole.Models
{
    public class SagaModel
    {
        public SagaTypeEnum SagaType { get; set; }
        public SagaStateEnum State { get; set; }
        public string Object { get; set; }
        public string LastErrorMessage { get; set; }
    }
}
