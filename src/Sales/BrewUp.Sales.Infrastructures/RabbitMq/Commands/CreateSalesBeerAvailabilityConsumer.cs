using BrewUp.Sales.Domain.CommandHandlers;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.RabbitMQ.Abstracts;
using Muflone.Transport.RabbitMQ.Consumers;

namespace BrewUp.Sales.Infrastructures.RabbitMq.Commands;

public sealed class CreateSalesBeerAvailabilityConsumer(
    IRepository repository,
    IMufloneConnectionFactory connectionFactory,
    ILoggerFactory loggerFactory)
    : CommandConsumerBase<CreateSalesBeerAvailablity>(repository, connectionFactory, loggerFactory)
{
    protected override ICommandHandlerAsync<CreateSalesBeerAvailablity> HandlerAsync { get; } = new CreateSalesBeerAvailablityCommandHandler(repository, loggerFactory);
}