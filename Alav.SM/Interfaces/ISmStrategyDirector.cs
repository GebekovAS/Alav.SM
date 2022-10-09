namespace Alav.SM.Interfaces
{
    public interface ISmStrategyDirector<TContextModel>
        where TContextModel: class
    {
        ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder);
    }
}
