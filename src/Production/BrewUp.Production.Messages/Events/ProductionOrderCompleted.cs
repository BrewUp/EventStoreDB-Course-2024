using System.Collections.Immutable;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Production.Messages.Events;

public sealed class ProductionOrderCompleted(ProductionOrderId aggregateId, IEnumerable<ProductionOrderRow> rows)
    : DomainEvent(aggregateId)
{
    public readonly ProductionOrderId ProductionOrderId = aggregateId;
    public readonly IImmutableList<ProductionOrderRow> Rows = rows.ToImmutableList();
}