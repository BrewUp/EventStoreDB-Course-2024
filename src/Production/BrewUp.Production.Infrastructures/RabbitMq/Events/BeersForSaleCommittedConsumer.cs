using BrewUp.Production.ReadModel.Adapters;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Events;

public sealed class BeersForSaleCommittedConsumer(
    IServiceBus serviceBus,
    IMufloneConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<BeersForSaleCommitted>(mufloneConnectionFactory, loggerFactory)
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSaleCommitted>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BeersForSaleCommitted>>
    {
        new BeersForSaleCommittedEventHandler(loggerFactory, serviceBus)
    };
}