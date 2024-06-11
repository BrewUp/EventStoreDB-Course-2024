using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesOrderCompletedEventHandler(ILoggerFactory loggerFactory, ISalesOrderService salesOrderService)
    : DomainEventHandlerAsync<SalesOrderCompleted>(loggerFactory)
{
    public override async Task HandleAsync(SalesOrderCompleted @event, CancellationToken cancellationToken = new ())
    {
        await salesOrderService.CompleteSalesOrderAsync(@event.SalesOrderId, cancellationToken);
    }
}