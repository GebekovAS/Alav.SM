using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace Alav.SM
{
    /// <inheritdoc />

    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
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
