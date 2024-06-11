using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.Messages.Events;

public sealed class BeerAvailabilityWithdrawn(
    BeerId aggregateId,
    Guid commitId,
    BeerName beerName,
    Availability availability)
    : DomainEvent(aggregateId, commitId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
    public readonly Availability Availability = availability;
}