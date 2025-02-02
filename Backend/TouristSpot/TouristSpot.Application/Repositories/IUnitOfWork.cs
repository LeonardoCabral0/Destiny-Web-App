namespace TouristSpot.Application.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
