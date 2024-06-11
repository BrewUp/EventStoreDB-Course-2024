using BrewUp.Sales.ReadModel.Adapters;
using BrewUp.Shared.Messages;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class BeersForSalesOrderAvailableConsumer(
    IServiceBus serviceBus,
    IMufloneConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<BeersForSalesOrderAvailable>(mufloneConnectionFactory, loggerFactory)
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersForSalesOrderAvailable>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BeersForSalesOrderAvailable>>
    {
        new BeersForSalesOrderAvailableEventHandler(loggerFactory, serviceBus)
    };
}