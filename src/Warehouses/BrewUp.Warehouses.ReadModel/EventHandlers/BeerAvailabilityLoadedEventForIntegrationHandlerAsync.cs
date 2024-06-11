using BrewUp.Shared.Messages.Sagas;
using BrewUp.Warehouses.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityLoadedEventForIntegrationHandlerAsync(
    ILoggerFactory loggerFactory,
    IEventBus eventBus) : DomainEventHandlerAsync<BeerAvailabilityLoaded>(loggerFactory)
{
    public override async Task HandleAsync(BeerAvailabilityLoaded @event, CancellationToken cancellationToken = new ())
    {
        var correlationId =
            new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);
        
        BeerAvailabilityCommunicated integrationEvent = new(@event.BeerId, correlationId, @event.BeerName, @event.Availability);
        await eventBus.PublishAsync(integrationEvent, cancellationToken);
    }
}