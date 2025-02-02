using AutoMapper;
using TouristSpot.Application.Repositories;
using TouristSpot.Application.Validators;
using TouristSpot.Domain.Exception;

namespace TouristSpot.Application.UseCases.TouristSpotServices.Register
{
    public class RegisterTouristSpot : IRegisterTouristSpot
    {
        private readonly IMapper _mapper;
        private readonly ITouristSpotRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterTouristSpot(IMapper mapper, ITouristSpotRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<OutputRegisterTouristSpot> Execute(InputRegisterTouristSpot input)
        {
            ValidateInput(input);
            var touristSpot = _mapper.Map<Domain.Entities.TouristSpot>(input);
            await _repository.Add(touristSpot);
            await _unitOfWork.Commit();
            return _mapper.Map<OutputRegisterTouristSpot>(touristSpot);
        }

        private void ValidateInput(InputRegisterTouristSpot input)
        {
            var validator = new RegisterTouristSpotValidator();
            var validatorResult = validator.Validate(input);
            if (!validatorResult.IsValid)
            {
                var errorsMessages = validatorResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorsMessages);
            }
        }
    }
}
