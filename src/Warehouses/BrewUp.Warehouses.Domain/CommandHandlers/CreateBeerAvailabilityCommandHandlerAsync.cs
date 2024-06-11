using BrewUp.Warehouses.Domain.Entities;
using BrewUp.Warehouses.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Warehouses.Domain.CommandHandlers;

public sealed class CreateBeerAvailabilityCommandHandlerAsync(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<CreateBeerAvailablity>(repository, loggerFactory)
{
    public override async Task ProcessCommand(CreateBeerAvailablity command, CancellationToken cancellationToken = default)
    {
        var aggregate = BeerAvailability.CreateBeerAvailability(command.BeerId, command.BeerName, command.Availability);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}