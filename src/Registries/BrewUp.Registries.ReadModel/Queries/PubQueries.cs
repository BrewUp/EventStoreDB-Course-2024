using System.Linq.Expressions;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Shared.Entities;
using BrewUp.Shared.ReadModel;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace BrewUp.Registries.ReadModel.Queries;

public sealed class PubQueries(IMongoClient mongoClient) : IQueries<Pub>
{
    private IMongoDatabase _database;
    
    public string DatabaseName { get; private set; }

    public void SetDatabaseName(string databaseName)
    {
        DatabaseName = databaseName;
        _database = mongoClient.GetDatabase(databaseName);
    }
    
    public async Task<Pub> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var collection = _database.GetCollection<Pub>(nameof(Pub));
        var filter = Builders<Pub>.Filter.Eq("_id", id);
        return (await collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken) > 0
            ? (await collection.FindAsync(filter, cancellationToken: cancellationToken)).First()
            : null)!;
    }

    public async Task<PagedResult<Pub>> GetByFilterAsync(Expression<Func<Pub, bool>>? query, int page, int pageSize, CancellationToken cancellationToken)
    {
        if (--page < 0)
            page = 0;

        var collection = _database.GetCollection<Pub>(nameof(Pub));
        var queryable = query != null
            ? collection.AsQueryable().Where(query)
            : collection.AsQueryable();

        var count = await queryable.CountAsync(cancellationToken: cancellationToken);
        var results = await queryable.Skip(page * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<Pub>(results, page, pageSize, count);
    }
}