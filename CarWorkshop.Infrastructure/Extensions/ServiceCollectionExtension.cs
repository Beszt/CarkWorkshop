
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarWorkshop.Infrastructure.Persistence;
using CarWorkshop.Infrastructure.Seeders;

namespace CarWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(options => options.UseNpgsql(
                configuration.GetConnectionString("CarWorkshop")
            ));

            services.AddScoped<CarWorkShopSeeder>();
        }
    }
}