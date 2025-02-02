using FluentValidation;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;
using TouristSpot.Domain.Entities;
using TouristSpot.Domain.Exception.ExceptionMessages;

namespace TouristSpot.Application.Validators
{
    public class RegisterTouristSpotValidator : AbstractValidator<InputRegisterTouristSpot>
    {
        public RegisterTouristSpotValidator()
        {
            RuleFor(touristSpot => touristSpot.Name).NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);
            RuleFor(touristSpot => touristSpot.Description).NotEmpty().WithMessage(ResourceMessageException.DESCRIPTION_EMPTY);
            RuleFor(touristSpot => touristSpot.Description.Length).LessThanOrEqualTo(100).WithMessage(ResourceMessageException.DESCRIPTION_MAX_LENGTH);
            RuleFor(touristSpot => touristSpot.Localization).NotEmpty().WithMessage(ResourceMessageException.LOCALIZATION_EMPTY);
            RuleFor(touristSpot => touristSpot.City).NotEmpty().WithMessage(ResourceMessageException.CITY_EMPTY);
            RuleFor(touristSpot => touristSpot.State).NotEmpty().WithMessage(ResourceMessageException.STATE_EMPTY);          
            When(touristSpot => string.IsNullOrEmpty(touristSpot.State) == false, () =>
            {
                RuleFor(touristSpot => touristSpot.State).Must(BeAValidState).WithMessage(ResourceMessageException.STATE_INVALID);
            });
        }

        private readonly string[] _stateAbbreviations = {
            "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
            "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI",
            "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
        };

        private bool BeAValidState(string state)
        {
            return _stateAbbreviations.Contains(state);
        }
    }
}
