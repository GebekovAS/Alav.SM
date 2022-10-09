using Alav.SM.TestConsole.Enums;

namespace Alav.SM.TestConsole.Models
{
    public class SagaModel
    {
        public SagaStateEnum State { get; set; }
        public string LastErrorMessage { get; set; }
    }
}
