using Foody.Food.Domain.Repositories;

namespace Foody.Web.Swagger.Extensions;

public static partial class Extensions
{
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/health");
        }

        return app;
    }
    public static IServiceCollection AddRestaurantServices(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        return services;
    }
}