using BrewUp.Production.Messages.Events;
using BrewUp.Production.ReadModel.EventHandlers;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Events;

public sealed class ProductionOrderCompletedConsumer(
    IProductionOrderService productionOrderService,
    IEventBus eventBus,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<ProductionOrderCompleted>(connectionFactory, loggerFactory)
{
    protected override IEnumerable<IDomainEventHandlerAsync<ProductionOrderCompleted>> HandlersAsync { get; } = new List<IDomainEventHandlerAsync<ProductionOrderCompleted>>
    {
        new ProductionOrderCompletedEventHandler(loggerFactory, productionOrderService),
        new ProductionOrderCompletedForIntegrationEventHandler(loggerFactory, eventBus)
    };
}