using BrewUp.Production.Messages.Events;
using BrewUp.Production.ReadModel.EventHandlers;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Events;

public sealed class ProductionOrderCreatedConsumer(
    IProductionOrderService productionOrderService,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<ProductionOrderCreated>(connectionFactory, loggerFactory)
{
    protected override IEnumerable<IDomainEventHandlerAsync<ProductionOrderCreated>> HandlersAsync { get; } = new List<IDomainEventHandlerAsync<ProductionOrderCreated>>
    {
        new ProductionOrderCreatedEventHandler(loggerFactory, productionOrderService)
    };
}