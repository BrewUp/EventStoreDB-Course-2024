using BrewUp.Sales.Messages.Events;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCreatedForIntegrationEventHandlerAsync(
    ILoggerFactory loggerFactory,
    IEventBus eventBus) : DomainEventHandlerBase<SalesOrderCreated>(loggerFactory)
{
    public override async Task HandleAsync(SalesOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        BeersForSaleRequested beersForSaleRequested = new(new OrderId(@event.SalesOrderId.Value),
            Guid.NewGuid(), 
            @event.Rows.Select(x => new BeerCommittedRow(x.BeerId.Value, x.BeerName.Value, x.Quantity)));
        await eventBus.PublishAsync(beersForSaleRequested, cancellationToken);
    }
}