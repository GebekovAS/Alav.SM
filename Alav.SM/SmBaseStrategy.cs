using Alav.SM.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    public abstract class SmBaseStrategy<TSagaModel> : ISmStrategy<TSagaModel>
        where TSagaModel: class
    {
        /// <inheritdoc />
        public virtual void Process(TSagaModel sagaModel)
        { }

        /// <inheritdoc />
        public virtual Task ProcessAsync(TSagaModel sagaModel, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
