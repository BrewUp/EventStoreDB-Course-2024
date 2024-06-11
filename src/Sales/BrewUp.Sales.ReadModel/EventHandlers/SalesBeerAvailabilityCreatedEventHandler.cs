using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesBeerAvailabilityCreatedEventHandler(
    ILoggerFactory loggerFactory,
    ISalesBeerAvailabilityService salesBeerAvailabilityService)
    : DomainEventHandlerAsync<SalesBeerAvailabilityCreated>(loggerFactory)
{
    private readonly ISalesBeerAvailabilityService _salesBeerAvailabilityService = salesBeerAvailabilityService ?? throw new ArgumentNullException(nameof(salesBeerAvailabilityService));

    public override async Task HandleAsync(SalesBeerAvailabilityCreated @event, CancellationToken cancellationToken = new())
    {
        await _salesBeerAvailabilityService.CreateSalesBeerAvailabilityAsync(@event.BeerId, @event.BeerName, @event.Availability, cancellationToken);
    }
}