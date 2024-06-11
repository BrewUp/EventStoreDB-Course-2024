using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeerAvailabilityWithdrawnConsumer(
    IEventBus eventBus,
    IBeerAvailabilityService beerAvailabilityService,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<BeerAvailabilityWithdrawn>(connectionFactory, loggerFactory)
{
    protected override IEnumerable<IDomainEventHandlerAsync<BeerAvailabilityWithdrawn>> HandlersAsync { get; } = new List<IDomainEventHandlerAsync<BeerAvailabilityWithdrawn>>
    {
        new BeerAvailabilityWithdrawnEventHandler(loggerFactory, beerAvailabilityService),
        new BeerAvailabilityWithdrawnForIntegrationEventHandler(loggerFactory, eventBus)
    };
}