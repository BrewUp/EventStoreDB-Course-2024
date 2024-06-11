using BrewUp.Production.Messages.Events;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Production.ReadModel.EventHandlers;

public sealed class ProductionOrderCreatedEventHandler(
    ILoggerFactory loggerFactory,
    IProductionOrderService productionOrderService)
    : DomainEventHandlerAsync<ProductionOrderCreated>(loggerFactory)
{
    public override async Task HandleAsync(ProductionOrderCreated @event, CancellationToken cancellationToken = new())
    {
        await productionOrderService.CreateProductionOrderAsync(@event.ProductionOrderId, @event.ProductionOrderNumber,
            @event.OrderDate, @event.Rows, cancellationToken);
    }
}