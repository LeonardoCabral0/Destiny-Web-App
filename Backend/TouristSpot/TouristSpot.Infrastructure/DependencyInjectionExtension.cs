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
            services.AddDbContext(configuration);
        }

        private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("Connection");
            var connectionString = "Data Source=DESKTOP-VTOFJ87;Initial Catalog=touristspot;User ID=sa;Password=root;Trusted_Connection=True; Encrypt=True; TrustServerCertificate=True;";
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
    }
}
