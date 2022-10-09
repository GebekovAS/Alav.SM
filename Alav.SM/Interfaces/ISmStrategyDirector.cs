namespace Alav.SM.Interfaces
{
    public interface ISmStrategyDirector<TSagaModel>
        where TSagaModel: class
    {
        ISmStrategyBuilder<TSagaModel> Construct(ISmStrategyBuilder<TSagaModel> builder);
    }
}
