using TouristSpot.Application.UseCases.TouristSpotServices.Get;

namespace TouristSpot.Application.Repositories
{
    public interface ITouristSpotRepository
    {
        public Task Add(Domain.Entities.TouristSpot touristSpot);
        public Task<List<Domain.Entities.TouristSpot>> GetAll(InputGetTouristSpot queryObject);
    }
}
