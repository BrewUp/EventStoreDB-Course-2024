using BrewUp.Production.Messages.Commands;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Messages;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Production.ReadModel.Adapters;

public sealed class BeersForSaleCommittedEventHandler(
    ILoggerFactory loggerFactory,
    IServiceBus serviceBus) : IntegrationEventHandlerAsync<BeersForSaleCommitted>(loggerFactory)
{
    public override async Task HandleAsync(BeersForSaleCommitted @event, CancellationToken cancellationToken = new ())
    {
        CreateProductionOrder createProductionOrder = new(new ProductionOrderId(@event.OrderId.Value),
            Guid.NewGuid(),
            new ProductionOrderNumber(@event.OrderNumber.Value),
            new OrderDate(DateTime.UtcNow),
            @event.Rows.Select(x =>
                new ProductionOrderRow(new BeerId(x.BeerId), new BeerName(x.BeerName), x.Quantity)));

        await serviceBus.SendAsync(createProductionOrder, cancellationToken);
    }
}