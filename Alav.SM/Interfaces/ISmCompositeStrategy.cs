using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Composite strategy
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmCompositeStrategy<TContextModel> : ISmStrategy<TContextModel>
        where TContextModel: class
    {
        /// <summary>
        /// Add strategy to chain
        /// </summary>
        /// <typeparam name="TStrategy">Strategy</typeparam>
        ISmCompositeStrategy<TContextModel> AddStrategy<TStrategy>()
            where TStrategy: ISmStrategy<TContextModel>;

        /// <summary>
        /// Remove strategy
        /// </summary>
        /// <typeparam name="TStrategy">Strategy</typeparam>
        ISmCompositeStrategy<TContextModel> RemoveStrategy<TStrategy>()
            where TStrategy : ISmStrategy<TContextModel>;
    }
}
