using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarWorkshopDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("CarWorkshop")
        ));

        services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<CarWorkshopDbContext>();

        services.AddScoped<CarWorkShopSeeder>();

        services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
    }
}