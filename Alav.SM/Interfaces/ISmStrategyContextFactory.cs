namespace Alav.SM.Interfaces
{
    public interface ISmStrategyContextFactory<TSagaModel>
        where TSagaModel: class
    {
        ISmStrategyContext<TSagaModel> GetContext(TSagaModel sagaModel);
    }
}
