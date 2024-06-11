using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Sales.Messages.Events;

public sealed class SalesOrderCreated(
    SalesOrderId aggregateId,
    SalesOrderNumber salesOrderNumber,
    PubId pubId,
    PubName pubName,
    OrderDate orderDate,
    IEnumerable<SalesOrderRowDto> rows)
    : DomainEvent(aggregateId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly SalesOrderNumber SalesOrderNumber = salesOrderNumber;
    public readonly PubId PubId = pubId;
    public readonly PubName PubName = pubName;
    public readonly OrderDate OrderDate = orderDate;

    public readonly IEnumerable<SalesOrderRowDto> Rows = rows;
}