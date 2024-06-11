using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.EventHandlers;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeerAvailabilityLoadedConsumer(
    IBeerAvailabilityService beerAvailabilityService,
    IEventBus eventBus,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<BeerAvailabilityLoaded>(connectionFactory,
        loggerFactory)
{
    protected override IEnumerable<IDomainEventHandlerAsync<BeerAvailabilityLoaded>> HandlersAsync { get; } = new List<IDomainEventHandlerAsync<BeerAvailabilityLoaded>>
    {
        new BeerAvailabilityLoadedEventHandlerAsync(loggerFactory, beerAvailabilityService),
        new BeerAvailabilityLoadedEventForIntegrationHandlerAsync(loggerFactory, eventBus)
    };
}