using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Commands;

public sealed class CompleteSalesOrderConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<CompleteSalesOrder>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<CompleteSalesOrder> HandlerAsync { get; } = new CompleteSalesOrderCommandHandler(repository, loggerFactory);
}