namespace TouristSpot.Application.UseCases.TouristSpotServices.Get
{
    public record OutputShortGetTouristSpot(int Id, string Name, string Description, string Localization, string City, string State, DateTime CreatedDate);
}
