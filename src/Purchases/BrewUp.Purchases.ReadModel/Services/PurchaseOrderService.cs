﻿using Brewup.Purchases.ReadModel.Entities;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Purchases.ReadModel.Services;

public class PurchaseOrderService(ILoggerFactory loggerFactory, IPersister persister)
	: ServiceBase(loggerFactory, persister), IPurchaseOrderService
{
	public async Task CreatePurchaseOrderAsync(PurchaseOrderId purchaseOrderId, OrderDate date, IEnumerable<PurchaseOrderRow> rows,
		SupplierId supplierId, CancellationToken cancellationToken)
	{
		var order = PurchaseOrder.Create(purchaseOrderId, date, rows, supplierId);

		await Persister.InsertAsync(order, cancellationToken);
	}
}