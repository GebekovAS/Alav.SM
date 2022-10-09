using Alav.SM.Interfaces;

namespace Alav.SM
{
    public class SmDirector<TSagaModel> : ISmStrategyDirector<TSagaModel>
        where TSagaModel: class
    {
        public ISmStrategyBuilder<TSagaModel> Construct(ISmStrategyBuilder<TSagaModel> builder)
        {
            return builder
                .BuildRootStrategy()
                .BuildSubStrategies();
        }
    }
}
