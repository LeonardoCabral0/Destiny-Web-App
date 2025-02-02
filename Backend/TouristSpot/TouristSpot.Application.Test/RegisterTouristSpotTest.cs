using FluentAssertions;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;
using TouristSpot.Application.Validators;
using TouristSpot.Domain.Exception.ExceptionMessages;

namespace TouristSpot.Application.Test
{
    public class RegisterTouristSpotTest
    {
        [Fact]
        public void Sucess_Valid_Input()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Name_Empty()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.NAME_EMPTY));
        }

        [Fact]
        public void Error_Description_Empty()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.DESCRIPTION_EMPTY));
        }

        [Fact]
        public void Error_Localization_Empty()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "",
                City: "Rio de Janeiro",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.LOCALIZATION_EMPTY));
        }

        [Fact]
        public void Error_City_Empty()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.CITY_EMPTY));
        }

        [Fact]
        public void Error_State_Empty()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: ""
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.STATE_EMPTY));
        }

        [Fact]
        public void Error_State_Invalid()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "HU"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.STATE_INVALID));
        }

        [Fact]
        public void Error_State_Invalid_Length_Greater_Two()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua icônica de Jesus Cristo no topo do morro do Corcovado.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "HUAA"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.STATE_INVALID));
        }

        [Fact]
        public void Error_Description_MaxLength()
        {
            var registerValidator = new RegisterTouristSpotValidator();

            var input = new InputRegisterTouristSpot(
                Name: "Cristo Redentor",
                Description: "Uma estátua monumental e icônica de Jesus Cristo, localizada no topo do famoso morro do Corcovado, no Rio de Janeiro.",
                Localization: "Parque Nacional da Tijuca",
                City: "Rio de Janeiro",
                State: "RJ"
            );

            var result = registerValidator.Validate(input);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(error => error.ErrorMessage.Equals(ResourceMessageException.DESCRIPTION_MAX_LENGTH));
        }
    }
}