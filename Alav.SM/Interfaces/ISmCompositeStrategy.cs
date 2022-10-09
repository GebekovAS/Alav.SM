using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    public interface ISmCompositeStrategy<TSagaModel> : ISmStrategy<TSagaModel>
        where TSagaModel: class
    {
        ISmCompositeStrategy<TSagaModel> AddStrategy<TStrategy>()
            where TStrategy: ISmStrategy<TSagaModel>;

        ISmCompositeStrategy<TSagaModel> RemoveStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TSagaModel>;
    }
}
