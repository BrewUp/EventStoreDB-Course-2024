﻿using BrewUp.Infrastructures.MongoDb.Readmodel;
using BrewUp.Shared.ReadModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Muflone.Eventstore.gRPC.Persistence;

namespace BrewUp.Infrastructures.MongoDb;

public static class MongoDbHelper
{
	public static IServiceCollection AddMongoDb(this IServiceCollection services,
		MongoDbSettings mongoDbSettings)
	{
		services.AddSingleton<IMongoClient>(new MongoClient(mongoDbSettings.ConnectionString));
		services.AddScoped<IPersister, CustomPersister>();

		services.AddSingleton<IEventStorePositionRepository>(x =>
			new EventStorePositionRepository(x.GetRequiredService<ILogger<EventStorePositionRepository>>(), mongoDbSettings));

		return services;
	}
}