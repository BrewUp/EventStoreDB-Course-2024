using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace Brewup.Purchases.Domain.Entities;

public class PurchaseOrderLine(BeerId beerId, BeerName beerName, Quantity quantity, Cost cost)
	: Entity
{
	public BeerId BeerId { get; } = beerId;
	public BeerName BeerName { get; } = beerName;
	public Quantity Quantity { get; } = quantity;
	public Cost Cost { get; } = cost;
}