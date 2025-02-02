using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TouristSpot.Application.Repositories;
using TouristSpot.Application.UseCases.TouristSpotServices.Get;

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

        public async Task<List<Domain.Entities.TouristSpot>> GetAll(InputGetTouristSpot queryObject)
        {
            var query = _dbContext.TouristSpots.OrderBy(t => t.CreatedDate).AsNoTracking();

            if (!queryObject.Value.IsNullOrEmpty())
            {
                query = query.Where(touristSpot => touristSpot.Name.Contains(queryObject.Value) || touristSpot.Description.Contains(queryObject.Value) || touristSpot.Localization.Contains(queryObject.Value));
            }

            if (queryObject.OrderBy == "DESC")
            {
                query = query.OrderByDescending(t => t.CreatedDate);
            }

            query = query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);

            return await query.ToListAsync();
        }
    }
}
