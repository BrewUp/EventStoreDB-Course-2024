using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeersForSaleRequested(OrderId aggregateId, Guid correlationId, IEnumerable<BeerCommittedRow> rows)
    : IntegrationEvent(aggregateId, correlationId)
{
    public readonly OrderId OrderId = aggregateId;
    public readonly IEnumerable<BeerCommittedRow> Rows = rows;
}