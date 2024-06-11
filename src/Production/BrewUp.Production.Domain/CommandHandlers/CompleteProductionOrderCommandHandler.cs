using BrewUp.Production.Domain.Entities;
using BrewUp.Production.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Production.Domain.CommandHandlers;

public sealed class CompleteProductionOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<CompleteProductionOrder>(repository, loggerFactory)
{
    public override async Task ProcessCommand(CompleteProductionOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate = await Repository.GetByIdAsync<ProductionOrder>(command.AggregateId.Value);
        aggregate.CompleteProductionOrder(command.ProductionOrderId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}