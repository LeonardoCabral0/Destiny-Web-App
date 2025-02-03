using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristSpot.Application.Repositories;
using TouristSpot.Infrastructure.Repositories;

namespace TouristSpot.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();

            if (configuration.IsUnitTestEnviroment())
                return;

            services.AddDbContext(configuration);
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<APIDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITouristSpotRepository, TouristSpotRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static bool IsUnitTestEnviroment(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>("InMemoryTest");
        }
    }
}
