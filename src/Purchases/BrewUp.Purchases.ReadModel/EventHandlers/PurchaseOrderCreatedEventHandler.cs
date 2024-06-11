using BrewUp.Purchases.Messages.Events;
using BrewUp.Purchases.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderCreatedEventHandler(
    ILoggerFactory loggerFactory,
    IPurchaseOrderService purchaseOrderService)
    : DomainEventHandlerAsync<PurchaseOrderCreated>(loggerFactory)
{
    public readonly IPurchaseOrderService _purchaseOrderService = purchaseOrderService;

    public override async Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = new ())
    {
        await _purchaseOrderService.CreatePurchaseOrderAsync(@event.PurchaseOrderId, @event.OrderDate, @event.Rows,
            @event.SupplierId, cancellationToken);
    }
}