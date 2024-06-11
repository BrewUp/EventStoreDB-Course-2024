using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class LoadBeerAvailabilityConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<LoadBeerAvailability>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<LoadBeerAvailability> HandlerAsync { get; } = new LoadBeerAvailabilityCommandHandlerAsync(repository, loggerFactory);
}