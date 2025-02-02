using Application.UseCases.TouristSpot.Get;
using AutoMapper;
using TouristSpot.Application.Repositories;

namespace TouristSpot.Application.UseCases.TouristSpotServices.Get
{
    public class GetTouristSpots : IGetTouristSpots
    {
        private readonly ITouristSpotRepository _repository;
        private readonly IMapper _mapper;
        public GetTouristSpots(ITouristSpotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OutputGetTouristSpot> Execute(InputGetTouristSpot input)
        {
            var touristSpots = await _repository.GetAll(input);

            var result = new OutputGetTouristSpot();

            foreach (var touristSpot in touristSpots)
            {
                result.TouristsSpots.Add(_mapper.Map<OutputShortGetTouristSpot>(touristSpot));
            }

            return result;
        }

    }
}
