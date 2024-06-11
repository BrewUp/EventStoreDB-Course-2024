using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Warehouses.Messages.Commands;

public sealed class WithdrawalBySalesOrder(BeerId aggregateId, Guid commitId, Quantity quantity)
    : Command(aggregateId, commitId)
{
    public readonly BeerId BeerId = aggregateId;
    public readonly Quantity Quantity = quantity;
}