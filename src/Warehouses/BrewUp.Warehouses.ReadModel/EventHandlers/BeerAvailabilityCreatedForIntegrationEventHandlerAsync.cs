using BrewUp.Shared.Messages.Sagas;
using BrewUp.Warehouses.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityCreatedForIntegrationEventHandlerAsync(
    ILoggerFactory loggerFactory,
    IEventBus eventBus) : DomainEventHandlerAsync<BeerAvailabilityCreated>(loggerFactory)
{
    private readonly IEventBus _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));

    public override async Task HandleAsync(BeerAvailabilityCreated @event, CancellationToken cancellationToken = new ())
    {
        BeerAvailabilityCommunicated integrationEvent = new(@event.BeerId, Guid.Empty, @event.BeerName, @event.Availability);
        await _eventBus.PublishAsync(integrationEvent, cancellationToken);
    }
}