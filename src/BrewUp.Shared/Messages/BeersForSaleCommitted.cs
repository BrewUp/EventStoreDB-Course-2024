using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages;

public sealed class BeersForSaleCommitted(
    OrderId aggregateId,
    OrderNumber orderNumber,
    IEnumerable<BeerCommittedRow> rows)
    : IntegrationEvent(aggregateId)
{
    public readonly OrderId OrderId = aggregateId;
    public readonly OrderNumber OrderNumber = orderNumber;
    
    public readonly IEnumerable<BeerCommittedRow> Rows = rows;
}