using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeerAvailabilityCommunicated(
    BeerId aggregateId,
    Guid correlationId,
    BeerName beerName,
    Availability availability)
    : IntegrationEvent(aggregateId, correlationId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
    public readonly Availability Availability = availability;
}