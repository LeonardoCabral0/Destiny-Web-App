using TouristSpot.Application.UseCases.TouristSpotServices.Register;

namespace Utils.Inputs
{
    public class InputRegisterTouristSpotBuilder
    {
        public static InputRegisterTouristSpot Build()
        {
            return new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );
        }

        public static InputRegisterTouristSpot BuildWithNameEmpty()
        {
            return new InputRegisterTouristSpot(
                Name: "",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );
        }

        public static InputRegisterTouristSpot BuildDescriptionGreaterThanMaxSize()
        {
            return new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua monumental e icônica de Jesus Cristo, localizada no topo do famoso morro do Corcovado, no Rio de Janeiro.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );
        }

        public static InputRegisterTouristSpot BuildWithAllPropertysEmpty()
        {
            return new InputRegisterTouristSpot(
                Name: "",
                Description: "",
                Localization: "",
                City: "",
                State: ""
            );
        }
    }
}
