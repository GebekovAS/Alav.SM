using Alav.SM.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />
    public abstract class SmBaseStrategy<TContextModel> : ISmStrategy<TContextModel>
        where TContextModel: class
    {
        /// <inheritdoc />
        public virtual void Process(TContextModel context)
        { }

        /// <inheritdoc />
        public virtual Task ProcessAsync(TContextModel context, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
