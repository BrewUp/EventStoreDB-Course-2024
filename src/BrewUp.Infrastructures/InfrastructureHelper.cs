using BrewUp.Infrastructures.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using Muflone.Eventstore.gRPC;

namespace BrewUp.Infrastructures;

public static class InfrastructureHelper
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services,
		MongoDbSettings mongoDbSettings,
		EventStoreSettings eventStoreSettings)
	{
		services.AddMongoDb(mongoDbSettings);
		services.AddMufloneEventStore(eventStoreSettings.ConnectionString);

		return services;
	}
}