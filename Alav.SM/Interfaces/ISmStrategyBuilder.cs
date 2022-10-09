namespace Alav.SM.Interfaces
{
    public interface ISmStrategyBuilder<TSagaModel>
        where TSagaModel: class
    {
        ISmStrategyBuilder<TSagaModel> BuildRootStrategy();

        ISmStrategyBuilder<TSagaModel> BuildSubStrategies();

        ISmStrategy<TSagaModel> GetResult();
    }
}
