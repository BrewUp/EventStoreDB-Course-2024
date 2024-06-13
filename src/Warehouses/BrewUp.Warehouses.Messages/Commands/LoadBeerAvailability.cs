using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

public sealed class LoadBeerAvailability(BeerId aggregateId, Guid correlationId, Availability availability) : Command(aggregateId, correlationId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly Availability Availability = availability;
}