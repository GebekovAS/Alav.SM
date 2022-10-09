using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    public interface ISmCompositeStrategy<TContextModel> : ISmStrategy<TContextModel>
        where TContextModel: class
    {
        ISmCompositeStrategy<TContextModel> AddStrategy<TStrategy>()
            where TStrategy: ISmStrategy<TContextModel>;

        ISmCompositeStrategy<TContextModel> RemoveStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TContextModel>;
    }
}
