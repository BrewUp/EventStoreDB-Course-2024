﻿using BrewUp.Shared.Messages.Sagas;
using BrewUp.Warehouses.Messages.Events;
using BrewUp.Warehouses.ReadModel.Services;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Warehouses.ReadModel.EventHandlers;

public sealed class BeerAvailabilityWithdrawnForIntegrationEventHandler(
    ILoggerFactory loggerFactory,
    IEventBus eventBus) : DomainEventHandlerAsync<BeerAvailabilityWithdrawn>(loggerFactory)
{
    private readonly IEventBus _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));

    public override async Task HandleAsync(BeerAvailabilityWithdrawn @event, CancellationToken cancellationToken = new ())
    {
        cancellationToken.ThrowIfCancellationRequested();
        
        var correlationId =
            new Guid(@event.UserProperties.FirstOrDefault(u => u.Key.Equals("CorrelationId")).Value.ToString()!);

        BeerAvailabilityCommunicated integrationEvent = new(@event.BeerId, correlationId, @event.BeerName, @event.Availability);
        await _eventBus.PublishAsync(integrationEvent, cancellationToken);
    }
}