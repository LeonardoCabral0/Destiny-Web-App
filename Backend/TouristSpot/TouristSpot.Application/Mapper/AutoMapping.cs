using AutoMapper;
using TouristSpot.Application.UseCases.TouristSpotServices.Get;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;

namespace TouristSpot.Application.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            InputToDomain();
            DomainToOutput();
        }

        private void InputToDomain()
        {
            CreateMap<InputRegisterTouristSpot, Domain.Entities.TouristSpot>();
        }

        private void DomainToOutput()
        {
            CreateMap<Domain.Entities.TouristSpot, OutputRegisterTouristSpot>();
            CreateMap<Domain.Entities.TouristSpot, OutputShortGetTouristSpot>();
        }
    }
}