using Moq;
using TouristSpot.Application.Repositories;

namespace Utils.Repositories
{
    public class TouristSpotRepositoryBuilder
    {
        public static ITouristSpotRepository Build()
        {
            var mock = new Mock<ITouristSpotRepository>();

            return mock.Object;
        }
    }
}
