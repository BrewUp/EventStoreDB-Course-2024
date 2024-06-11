using BrewUp.Registries.Domain.CommandHandlers;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Messages.Sagas;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Registries.Infrastructures.RabbitMq.Commands;

public sealed class AskForBeerOriginConsumer(
    IQueries<Beer> queries,
    IEventBus eventBus,
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<AskForBeerOrigin>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<AskForBeerOrigin> HandlerAsync { get; } = new AskForBeerOriginCommandHandler(repository, loggerFactory, queries, eventBus);
}