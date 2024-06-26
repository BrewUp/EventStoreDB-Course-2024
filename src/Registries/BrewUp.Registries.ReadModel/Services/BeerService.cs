﻿using System.Linq.Expressions;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.Logging;

namespace BrewUp.Registries.ReadModel.Services;

public sealed class BeerService : ServiceBase, IBeerService
{
    private readonly IQueries<Beer> _queries;
    
    public BeerService(ILoggerFactory loggerFactory, IPersister persister, IQueries<Beer> queries) : base(loggerFactory, persister)
    {
        _queries = queries;
        _queries.SetDatabaseName("BrewUp_Registries");
    }

    public async Task<string> CreateBeerAsync(BeerId beerId, BeerName beerName, BeerType beerType,
        HomeBrewed homeBrewed, CancellationToken cancellationToken)
    {
        try
        {
            var beer = Beer.CreateBeer(beerId, beerName, beerType, homeBrewed);
            await Persister.InsertAsync(beer, cancellationToken);

            return beerId.Value.ToString();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error creating beer");
            throw;
        }
    }

    public async Task<PagedResult<BeerJson>> GetBeersAsync(Expression<Func<Beer, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        try
        {
            var beersResult = await _queries.GetByFilterAsync(query, page, pageSize, cancellationToken);
            
            return beersResult.TotalRecords > 0
                ? new PagedResult<BeerJson>(beersResult.Results.Select(r => r.ToJson()), beersResult.Page, beersResult.PageSize, beersResult.TotalRecords)
                : new PagedResult<BeerJson>(Enumerable.Empty<BeerJson>(), 0, 0, 0);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error reading beers");
            throw;
        }
    }
}