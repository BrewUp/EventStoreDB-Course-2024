using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class CreatePurchaseOrder(
    PurchaseOrderId aggregateId,
    Guid commitId,
    PurchaseOrderNumber purchaseOrderNumber,
    SupplierId supplierId,
    OrderDate orderDate,
    IEnumerable<PurchaseOrderRow> rows)
    : Command(aggregateId, commitId)
{
    public readonly PurchaseOrderId PurchaseOrderId = aggregateId;
    public readonly PurchaseOrderNumber PurchaseOrderNumber = purchaseOrderNumber;
    
    public readonly SupplierId SupplierId = supplierId;
    public readonly OrderDate OrderDate = orderDate;
    
    public readonly IEnumerable<PurchaseOrderRow> Rows = rows;
}