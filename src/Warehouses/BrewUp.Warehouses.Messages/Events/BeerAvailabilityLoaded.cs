using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.Messages.Events;

public sealed class BeerAvailabilityLoaded(
    BeerId aggregateId,
    Guid correlationId,
    BeerName beerName,
    Availability availability)
    : DomainEvent(aggregateId, correlationId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
    public readonly Availability Availability = availability;
}