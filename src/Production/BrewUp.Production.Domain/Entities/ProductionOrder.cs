﻿using BrewUp.Production.Domain.Helpers;
using BrewUp.Production.Messages.Events;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Production.Domain.Entities;

public sealed class ProductionOrder : AggregateRoot
{
    private ProductionOrderNumber _productionOrderNumber;
    private OrderDate _orderDate;

    private IEnumerable<ProductionOrderRow> _rows;
    
    private Status _status = Status.Created;
    
    protected ProductionOrder()
    {}
    
    #region CreateProductionOrder
    internal static ProductionOrder CreateProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Shared.Dtos.ProductionOrderRow> rows, Guid correlationId)
    {
        return new ProductionOrder(productionOrderId, productionOrderNumber, orderDate, rows, correlationId);
    }
    
    private ProductionOrder(ProductionOrderId productionOrderId, ProductionOrderNumber productionOrderNumber,
        OrderDate orderDate, IEnumerable<Shared.Dtos.ProductionOrderRow> rows, Guid correlationId)
    {
        RaiseEvent(new ProductionOrderCreated(productionOrderId, correlationId, productionOrderNumber, orderDate, rows));
    }

    private void Apply(ProductionOrderCreated @event)
    {
        Id = @event.AggregateId;
        
        _productionOrderNumber = @event.ProductionOrderNumber;
        _orderDate = @event.OrderDate;
        
        _rows = @event.Rows.ToDomainEntities();
        
        _status = Status.Created;
    }
    #endregion

    #region CompleteProductionOrder

    internal void CompleteProductionOrder(ProductionOrderId productionOrderId)
    {
        if (!_status.Equals(Status.Created))
        {
            RaiseEvent(new ProductionOrderAlreadyCompleted(productionOrderId));
            return;
        }
        
        RaiseEvent(new ProductionOrderCompleted(productionOrderId, _rows.ToDtos()));
    }
    
    private void Apply(ProductionOrderCompleted @event)
    {
        _status = Status.Completed;
    }
    
    private void Apply(ProductionOrderAlreadyCompleted @event)
    {
        // do nothing!;
    }
    #endregion
}