using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersForSalesOrderAvailable(OrderId aggregateId, IEnumerable<BrewedRow> rows)
    : IntegrationEvent(aggregateId)
{
    public readonly OrderId OrderId = aggregateId;
    public readonly IEnumerable<BrewedRow> Rows = rows;
}