namespace TouristSpot.Application.UseCases.TouristSpotServices.Get
{
    public record InputGetTouristSpot(string Value, string OrderBy, int Page = 1, int PageSize = 30);
}
