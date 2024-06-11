using BrewUp.Production.Domain.CommandHandlers;
using BrewUp.Production.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Production.Infrastructures.RabbitMq.Commands;

public sealed class CompleteProductionOrderConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<CompleteProductionOrder>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<CompleteProductionOrder> HandlerAsync { get; } = new CompleteProductionOrderCommandHandler(repository, loggerFactory);
}