using BrewUp.Shared.DomainIds;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderAlreadyCompleted(ProductionOrderId aggregateId) : DomainEvent(aggregateId)
{
    public readonly ProductionOrderId ProductionOrderId = aggregateId;
}