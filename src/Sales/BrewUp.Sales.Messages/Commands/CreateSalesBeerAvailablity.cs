using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CreateSalesBeerAvailablity(BeerId aggregateId, BeerName beerName, Availability availability)
    : Command(aggregateId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
    public readonly Availability Availability = availability;
}