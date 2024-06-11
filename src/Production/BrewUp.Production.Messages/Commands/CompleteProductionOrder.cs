using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Production.Messages.Commands;

public sealed class CompleteProductionOrder(ProductionOrderId aggregateId, Guid correlationId)
    : Command(aggregateId, correlationId)
{
    public readonly ProductionOrderId ProductionOrderId = aggregateId;
}