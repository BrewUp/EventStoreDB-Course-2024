using BrewUp.Shared.Messages.Sagas;
using BrewUp.Warehouses.Acl.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Events;

public sealed class BeersForSaleRequestedConsumer(
    IServiceBus serviceBus,
    IMufloneConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<BeersForSaleRequested>(mufloneConnectionFactory, loggerFactory)
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSaleRequested>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BeersForSaleRequested>>
    {
        new BeersForSaleRequestedEventHandler(loggerFactory, serviceBus)
    };
}