using BrewUp.Warehouses.Domain.Entities;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Warehouses.Domain.CommandHandlers;

public sealed class LoadBeerAvailabilityCommandHandlerAsync(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<LoadBeerAvailability>(repository, loggerFactory)
{
    public override async Task ProcessCommand(LoadBeerAvailability command, CancellationToken cancellationToken = default)
    {
        var aggregate = await Repository.GetByIdAsync<BeerAvailability>(command.AggregateId.Value, cancellationToken);
        aggregate.LoadAvailability(command.Availability, command.MessageId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}