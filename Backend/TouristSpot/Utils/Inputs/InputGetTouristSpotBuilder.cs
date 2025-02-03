using TouristSpot.Application.UseCases.TouristSpotServices.Get;

namespace Utils.Inputs
{
    public class InputGetTouristSpotBuilder
    {
        public static InputGetTouristSpot Build()
        {
            return new InputGetTouristSpot("", "ASC");
        }

        public static InputGetTouristSpot BuildDESC()
        {
            return new InputGetTouristSpot("", "DESC");
        }

        public static InputGetTouristSpot BuildWithPageAndPageSize(int page, int pageSize)
        {
            return new InputGetTouristSpot("","ASC",page, pageSize);
        }
        public static InputGetTouristSpot BuildWithValue(string value)
        {
            return new InputGetTouristSpot(value, "ASC");
        }

        public static InputGetTouristSpot BuildWithValueDESC(string value)
        {
            return new InputGetTouristSpot(value, "DESC");
        }

    }
}
