namespace TouristSpot.Application.Repositories
{
    public interface ITouristSpotRepository
    {
        public Task Add(Domain.Entities.TouristSpot touristSpot);
    }
}
