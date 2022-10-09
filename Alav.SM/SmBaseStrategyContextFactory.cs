using Alav.SM.Interfaces;

namespace Alav.SM
{
    public abstract class SmBaseStrategyContextFactory<TSagaModel> : ISmStrategyContextFactory<TSagaModel>
        where TSagaModel: class
    {
        public abstract ISmStrategyContext<TSagaModel> GetContext(TSagaModel sagaModel);
    }
}
