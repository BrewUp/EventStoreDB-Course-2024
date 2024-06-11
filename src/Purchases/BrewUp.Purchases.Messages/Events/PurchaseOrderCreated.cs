using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Purchases.Messages.Events;

public sealed class PurchaseOrderCreated(
    PurchaseOrderId aggregateId,
    Guid correlationId,
    SupplierId supplierId,
    OrderDate orderDate,
    IEnumerable<PurchaseOrderRow> rows)
    : DomainEvent(aggregateId, correlationId)
{
    public readonly PurchaseOrderId PurchaseOrderId = aggregateId;
    public readonly SupplierId SupplierId = supplierId;
    public readonly OrderDate OrderDate = orderDate;

    public readonly IEnumerable<PurchaseOrderRow> Rows = rows;
}