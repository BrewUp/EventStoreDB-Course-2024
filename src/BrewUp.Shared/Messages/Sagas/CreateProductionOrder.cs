using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class CreateProductionOrder(
    ProductionOrderId aggregateId,
    Guid correlationId,
    ProductionOrderNumber productionOrderNumber,
    OrderDate orderDate,
    IEnumerable<ProductionOrderRow> rows)
    : Command(aggregateId, correlationId)
{
    public readonly ProductionOrderId ProductionOrderId = aggregateId;
    public readonly ProductionOrderNumber ProductionOrderNumber = productionOrderNumber;
    
    public readonly OrderDate OrderDate = orderDate;
    
    public readonly IEnumerable<ProductionOrderRow> Rows = rows;
}