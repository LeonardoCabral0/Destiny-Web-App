using TouristSpot.Application.Repositories;

namespace TouristSpot.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIDbContext _dbContext;

        public UnitOfWork(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
