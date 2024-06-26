﻿using BrewUp.Sales.Acl.EventHandlers;
using BrewUp.Sales.ReadModel.Entities;
using BrewUp.Shared.Messages.Sagas;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Events;

public sealed class BeersAvailabilityCommunicatedConsumer(
    IServiceBus serviceBus,
    IQueries<SalesBeerAvailability> queries,
    IMufloneConnectionFactory mufloneConnectionFactory,
    ILoggerFactory loggerFactory)
    : IntegrationEventsConsumerBase<BeerAvailabilityCommunicated>(mufloneConnectionFactory, loggerFactory)
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeerAvailabilityCommunicated>> HandlersAsync { get; } = new List<IIntegrationEventHandlerAsync<BeerAvailabilityCommunicated>>
    {
        new BeerAvailabilityCommunicatedEventHandler(loggerFactory, serviceBus, queries)
    };
}