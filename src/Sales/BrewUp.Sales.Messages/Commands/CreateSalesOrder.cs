using BrewUp.Sales.SharedKernel.DomainIds;
using BrewUp.Sales.SharedKernel.Dtos;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Sales.Messages.Commands;

public sealed class CreateSalesOrder(
    SalesOrderId aggregateId,
    SalesOrderNumber salesOrderNumber,
    PubId pubId,
    PubName pubName,
    OrderDate orderDate,
    IEnumerable<SalesOrderRowDto> lines)
    : Command(aggregateId)
{
    public readonly SalesOrderId SalesOrderId = aggregateId;
    public readonly SalesOrderNumber SalesOrderNumber = salesOrderNumber;
    
    public readonly PubId PubId = pubId;
    public readonly PubName PubName = pubName;
    
    public readonly OrderDate OrderDate = orderDate;

    public readonly IEnumerable<SalesOrderRowDto> Lines = lines;
}