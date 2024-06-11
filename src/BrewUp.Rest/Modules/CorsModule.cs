namespace BrewUp.Rest.Modules
{
    public sealed class CorsModule : IModule
    {
        public bool IsEnabled { get; } = true;
        public int Order { get; } = 0;

        public IServiceCollection RegisterModule(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", corsBuilder =>
                    corsBuilder.AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader());
            });

            return builder.Services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}