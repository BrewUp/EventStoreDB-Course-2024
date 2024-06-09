﻿using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;

namespace BrewUp.Sales.ReadModel.Entities;

public class SalesBeerAvailability : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    
    public Availability Availability { get; private set; } = new(0, string.Empty);
    
    protected SalesBeerAvailability()
    {}

    public static SalesBeerAvailability CreateBeerAvailability(BeerId beerId, BeerName beerName,
        Availability availability) => new(beerId.ToString(), beerName.Value, availability);
    
    public void LoadBeerAvailability(Availability availability)
    {
        Availability = availability;
    }
    
    private SalesBeerAvailability(string beerId, string beerName, Availability availability)
    {
        Id = beerId;
        Name = beerName;

        Availability = availability;
    }
    
    public BeerAvailabilityJson ToJson() => new()
    {
        BeerId = Id,
        BeerName = Name,
        Availability = Availability
    };
}