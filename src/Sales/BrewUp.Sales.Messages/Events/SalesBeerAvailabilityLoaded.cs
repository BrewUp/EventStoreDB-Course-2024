using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesBeerAvailabilityLoaded(BeerId aggregateId, Guid correlationId, Availability availability)
    : DomainEvent(aggregateId, correlationId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly Availability Availability = availability;
}