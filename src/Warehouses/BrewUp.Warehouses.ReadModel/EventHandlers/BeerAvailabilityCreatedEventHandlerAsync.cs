using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityCreatedEventHandlerAsync(
    ILoggerFactory loggerFactory,
    IBeerAvailabilityService beerAvailabilityService)
    : DomainEventHandlerAsync<BeerAvailabilityCreated>(loggerFactory)
{
    public override async Task HandleAsync(BeerAvailabilityCreated @event, CancellationToken cancellationToken = new ())
    {
        await beerAvailabilityService.CreateBeerAvailabilityAsync(@event.BeerId, @event.BeerName, @event.Availability, cancellationToken);
    }
}