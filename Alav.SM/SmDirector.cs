using Alav.SM.Interfaces;

namespace Alav.SM
{
    public class SmDirector<TContextModel> : ISmStrategyDirector<TContextModel>
        where TContextModel: class
    {
        public ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder)
        {
            return builder
                .BuildRootStrategy()
                .BuildSubStrategies();
        }
    }
}
