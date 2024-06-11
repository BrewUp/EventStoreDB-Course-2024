using BrewUp.Shared.Messages.Sagas;
using BrewUp.Warehouses.Domain.CommandHandlers;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class AskForBeerAvailabilityConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<AskForBeerAvailability>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<AskForBeerAvailability> HandlerAsync { get; } = new AskForBeerAvailabilityCommandHandler(repository, loggerFactory);
}