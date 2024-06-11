using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderCreated(
    ProductionOrderId aggregateId,
    Guid correlationId,
    ProductionOrderNumber productionOrderNumber,
    OrderDate orderDate,
    IEnumerable<ProductionOrderRow> rows)
    : DomainEvent(aggregateId, correlationId)
{
    public readonly ProductionOrderId ProductionOrderId = aggregateId;
    public readonly ProductionOrderNumber ProductionOrderNumber = productionOrderNumber;
    
    public readonly OrderDate OrderDate = orderDate;
    
    public readonly IEnumerable<ProductionOrderRow> Rows = rows;
}