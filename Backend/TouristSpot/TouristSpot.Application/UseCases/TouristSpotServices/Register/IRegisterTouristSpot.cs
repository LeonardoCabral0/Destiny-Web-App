namespace TouristSpot.Application.UseCases.TouristSpotServices.Register
{
    public interface IRegisterTouristSpot
    {
        public Task<OutputRegisterTouristSpot> Execute(InputRegisterTouristSpot input);
    }
}
