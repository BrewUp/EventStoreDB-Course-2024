using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CompleteSalesOrder(SalesOrderId aggregateId, IEnumerable<BrewedRow> rows) : Command(aggregateId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly IEnumerable<BrewedRow> Rows = rows;
}