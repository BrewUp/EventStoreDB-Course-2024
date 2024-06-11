using BrewUp.Sales.Messages.Events;
using BrewUp.Sales.ReadModel.Services;
using Microsoft.Extensions.Logging;

namespace BrewUp.Sales.ReadModel.EventHandlers;

public sealed class SalesBeerAvailabilityLoadedEventHandler(
    ILoggerFactory loggerFactory,
    ISalesBeerAvailabilityService salesBeerAvailabilityService)
    : DomainEventHandlerBase<SalesBeerAvailabilityLoaded>(loggerFactory)
{
    private readonly ISalesBeerAvailabilityService _salesBeerAvailabilityService = salesBeerAvailabilityService ?? throw new ArgumentNullException(nameof(salesBeerAvailabilityService));

    public override async Task HandleAsync(SalesBeerAvailabilityLoaded @event, CancellationToken cancellationToken = new ())
    {
        await _salesBeerAvailabilityService.LoadSalesBeerAvailabilityAsync(@event.BeerId, @event.Availability,
            cancellationToken);
    }
}