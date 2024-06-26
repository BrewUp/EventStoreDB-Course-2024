﻿using BrewUp.Production.Domain.Entities;
using BrewUp.Production.Messages.Commands;
using BrewUp.Shared.Messages.Sagas;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Production.Domain.CommandHandlers;

public sealed class CreateProductionOrderCommandHandler(IRepository repository, ILoggerFactory loggerFactory)
    : CommandHandlerBaseAsync<CreateProductionOrder>(repository, loggerFactory)
{
    public override async Task ProcessCommand(CreateProductionOrder command, CancellationToken cancellationToken = default)
    {
        var aggregate = ProductionOrder.CreateProductionOrder(command.ProductionOrderId, command.ProductionOrderNumber,
            command.OrderDate, command.Rows, command.MessageId);
        await Repository.SaveAsync(aggregate, Guid.NewGuid());
    }
}