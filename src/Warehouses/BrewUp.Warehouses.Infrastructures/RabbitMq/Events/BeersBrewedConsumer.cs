using BrewUp.Shared.Messages;
using BrewUp.Warehouses.ReadModel.Adapters;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeersBrewedConsumer(
    IBeerAvailabilityService beerAvailabilityService,
    IServiceBus serviceBus,
    IEventBus eventBus,
    IMufloneConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<BeersBrewed>(mufloneConnectionFactory, loggerFactory)
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersBrewed>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BeersBrewed>>
    {
        new BeersBrewedEventHandler(loggerFactory, serviceBus, eventBus, beerAvailabilityService)
    };
}