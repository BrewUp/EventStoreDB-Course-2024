using System.Collections.Immutable;
using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesOrderCompleted(SalesOrderId aggregateId, IEnumerable<SalesOrderRowDto> rows)
    : DomainEvent(aggregateId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly IImmutableList<SalesOrderRowDto> Rows = rows.ToImmutableList();
}