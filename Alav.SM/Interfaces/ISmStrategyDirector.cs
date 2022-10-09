using Alav.DI.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Alav.SM.Interfaces
{
    /// <summary>
    /// Builder director
    /// </summary>
    /// <typeparam name="TContextModel"></typeparam>
    public interface ISmStrategyDirector<TContextModel>
        where TContextModel: class
    {
        /// <summary>
        /// Construct builder
        /// </summary>
        /// <param name="builder">builder</param>
        ISmStrategyBuilder<TContextModel> Construct(ISmStrategyBuilder<TContextModel> builder);
    }
}
