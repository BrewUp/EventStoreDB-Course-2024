using BrewUp.Production.Messages.Events;
using BrewUp.Production.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Production.ReadModel.EventHandlers;

public sealed class ProductionOrderCompletedEventHandler(
    ILoggerFactory loggerFactory,
    IProductionOrderService productionOrderService)
    : DomainEventHandlerAsync<ProductionOrderCompleted>(loggerFactory)
{
    public override async Task HandleAsync(ProductionOrderCompleted @event, CancellationToken cancellationToken = new ())
    {
        await productionOrderService.CompleteProductionOrderAsync(@event.ProductionOrderId, cancellationToken);
    }
}