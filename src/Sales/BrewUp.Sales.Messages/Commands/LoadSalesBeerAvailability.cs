using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class LoadSalesBeerAvailability(BeerId aggregateId, Availability availability) : Command(aggregateId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly Availability Availability = availability;
}