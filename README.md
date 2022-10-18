# Alav.SM [![Build status](https://ci.appveyor.com/api/projects/status/9f21wymvsaokk6sf?svg=true)](https://ci.appveyor.com/project/GebekovAS/alav-sm) [![NuGet Package](https://img.shields.io/nuget/v/Alav.SM?logo=1.0.2)](https://www.nuget.org/packages/Alav.SM)

> Alav.SM - tools for Implementing the State Machine. Allows you to implement the state machine pattern to perform a chain of complex asynchronous operations related to common business logic

## Installation

Install the [NuGet Package](https://www.nuget.org/packages/Alav.SM).

### Package Manager Console

```
Install-Package Alav.SM
```

### .NET Core CLI

```
dotnet add package Alav.SM
```

## Usage

### Base app structure
- **Strategies**
  - ```TestStrategy : SmBaseStrategy<SagaModel>```
- **Builders**
  - ```TestBuilder : SmBaseStrategyBuilder<SagaModel>```
- **Contexts**
  - ```TestStrategyContext : SmBaseStrategyContext<SagaModel>```
- **Models**
  - ```SagaModel : IStrategyContextModel```
- **Enums**
  - ```SagaStateEnum```
- ```SagaRepository : SmBaseRepository<SagaModel>```
- ```StrategyContextFactory : SmBaseStrategyContextFactory<SagaModel>```

### Startup.cs

```CS
    using Alav.DI.Extensions;

    public void ConfigureServices(IServiceCollection services){
        ...
            services.Scan(); //Alav.DI
        ...
    }
```
>**Alav.SM** uses the **[Alav.DI](https://github.com/GebekovAS/Alav.DI)** tool to register services

### Run processing
```CS
    var stateMachine = services.GetService<SmMachine<SagaRepository, StrategyContextFactory, SagaModel>>();
    await stateMachine.ProcessAsync(correlationId);
```