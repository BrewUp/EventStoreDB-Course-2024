using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class LoadSalesBeerAvailabilityCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<LoadSalesBeerAvailability>(repository, loggerFactory)
{
    public override async Task ProcessCommand(LoadSalesBeerAvailability command, CancellationToken cancellationToken = default)
    {
        var aggregate = await Repository.GetByIdAsync<SalesBeerAvailability>(command.BeerId.Value);
        aggregate.LoadAvailability(command.Availability, command.MessageId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}