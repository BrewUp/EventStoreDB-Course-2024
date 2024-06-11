using BrewUp.Purchases.Domain.CommandHandlers;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Purchases.Infrastructures.RabbitMq.Commands;

public sealed class CreatePurchaseOrderConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<CreatePurchaseOrder>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<CreatePurchaseOrder> HandlerAsync { get; } = new CreatePurchaseOrderCommandHandlerAsync(repository, loggerFactory);
}