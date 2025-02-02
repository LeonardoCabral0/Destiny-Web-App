using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TouristSpot.Application.Repositories;

namespace TouristSpot.Infrastructure.Repositories
{
    public class TouristSpotRepository : ITouristSpotRepository
    {
        private readonly APIDbContext _dbContext;

        public TouristSpotRepository(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Domain.Entities.TouristSpot touristSpot)
        {
            await _dbContext.TouristSpots.AddAsync(touristSpot);
        }
    }
}
