using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityLoadedEventHandlerAsync(
    ILoggerFactory loggerFactory,
    IBeerAvailabilityService beerAvailabilityService)
    : DomainEventHandlerAsync<BeerAvailabilityLoaded>(loggerFactory)
{
    public override async Task HandleAsync(BeerAvailabilityLoaded @event, CancellationToken cancellationToken = new ())
    {
        await beerAvailabilityService.LoadBeerAvailabilityAsync(@event.BeerId, @event.Availability, cancellationToken);
    }
}