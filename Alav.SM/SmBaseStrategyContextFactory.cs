using Alav.SM.Interfaces;

namespace Alav.SM
{
    public abstract class SmBaseStrategyContextFactory<TContextModel> : ISmStrategyContextFactory<TContextModel>
        where TContextModel: class
    {
        public abstract ISmStrategyContext<TContextModel> GetContext(TContextModel context);
    }
}
