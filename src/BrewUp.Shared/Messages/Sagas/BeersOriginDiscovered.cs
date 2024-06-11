using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Messages.Sagas;

public sealed class BeerOriginDiscovered(BeerId aggregateId, Guid correlationId, HomeBrewed homeBrewed)
    : IntegrationEvent(aggregateId, correlationId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly HomeBrewed HomeBrewed = homeBrewed;
}