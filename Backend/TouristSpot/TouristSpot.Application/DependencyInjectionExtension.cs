using Application.UseCases.TouristSpot.Get;
using Microsoft.Extensions.DependencyInjection;
using TouristSpot.Application.Mapper;
using TouristSpot.Application.UseCases.TouristSpotServices.Get;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;

namespace TouristSpot.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {

            services.AddScoped(options => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterTouristSpot, RegisterTouristSpot>();
            services.AddScoped<IGetTouristSpots, GetTouristSpots>();
        }
    }
}
