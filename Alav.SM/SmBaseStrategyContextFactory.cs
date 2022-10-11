﻿using Alav.DI.Attributes;
using Alav.SM.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Alav.SM
{
    /// <inheritdoc />
    [ADI(ServiceLifetime = DI.Enums.ADIServiceLifetime.Singleton)]
    public abstract class SmBaseStrategyContextFactory<TContextModel, TStrategyState> : ISmStrategyContextFactory<TContextModel, TStrategyState>
        where TStrategyState: Enum
        where TContextModel: IStrategyContextModel<TStrategyState>
    {
        /// <inheritdoc />
        public abstract ISmStrategyContext<TContextModel, TStrategyState> GetContext(TContextModel context);
    }
}
