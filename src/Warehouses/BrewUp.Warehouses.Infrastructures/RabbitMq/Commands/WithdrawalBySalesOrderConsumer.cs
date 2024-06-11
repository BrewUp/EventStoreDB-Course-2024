using BrewUp.Warehouses.Domain.CommandHandlers;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Warehouses.Infrastructures.RabbitMq.Commands;

public sealed class WithdrawalBySalesOrderConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<WithdrawalBySalesOrder>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<WithdrawalBySalesOrder> HandlerAsync { get; } = new WithdrawalBySalesOrderCommandHandler(repository, loggerFactory);
}