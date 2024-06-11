using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class AskForBeerAvailability(BeerId aggregateId, Guid commitId, BeerName beerName)
    : Command(aggregateId, commitId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly BeerName BeerName = beerName;
}