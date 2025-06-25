using Foody.Food.Domain.Repositories;
using Foody.Shared.Messaging.Bases;
using FluentValidation;
using Foody.Food.API.Application.Restaurants.Commands.AddRestaurant;
using Foody.Shared.Kernel.Bases;

namespace Foody.Food.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<AddRestaurantCommand, Guid>, AddRestaurantHandler>();
        
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes:true);
        
        return services;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRestaurantRepository>(provider => 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var unitOfWork = provider.GetRequiredService<IUnitOfWork>();
            return new RestaurantRepository(connectionString!, unitOfWork);
        });
        return services;
    }
}