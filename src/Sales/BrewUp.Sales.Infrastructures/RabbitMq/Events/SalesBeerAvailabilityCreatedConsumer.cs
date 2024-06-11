using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.EventHandlers;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class SalesBeerAvailabilityCreatedConsumer(
    ISalesBeerAvailabilityService salesBeerAvailabilityService,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : DomainEventsConsumerBase<SalesBeerAvailabilityCreated>(connectionFactory, loggerFactory)
{
    
    protected override IEnumerable<IDomainEventHandlerAsync<SalesBeerAvailabilityCreated>> HandlersAsync { get; } = new List<IDomainEventHandlerAsync<SalesBeerAvailabilityCreated>>
    {
        new SalesBeerAvailabilityCreatedEventHandler(loggerFactory, salesBeerAvailabilityService)
    };
}