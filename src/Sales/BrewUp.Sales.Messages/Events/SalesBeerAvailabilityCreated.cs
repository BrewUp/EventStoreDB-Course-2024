using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesBeerAvailabilityCreated(BeerId aggregateId, BeerName beerName, Availability availability)
    : DomainEvent(aggregateId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
    public readonly Availability Availability = availability;
}