using BrewUp.Sales.Domain.Entities;
using BrewUp.Sales.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Sales.Domain.CommandHandlers;

public sealed class CreateSalesBeerAvailablityCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<CreateSalesBeerAvailablity>(repository, loggerFactory)
{
    public override async Task ProcessCommand(CreateSalesBeerAvailablity command, CancellationToken cancellationToken = default)
    {
        var aggregate = SalesBeerAvailability.CreateBeerAvailability(command.BeerId, command.BeerName, command.Availability);
        await Repository.SaveAsync(aggregate, Guid.NewGuid(), cancellationToken);
    }
}