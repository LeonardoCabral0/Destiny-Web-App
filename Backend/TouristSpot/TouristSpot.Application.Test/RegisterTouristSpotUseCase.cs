using FluentAssertions;
using TouristSpot.Application.UseCases.TouristSpotServices.Register;
using TouristSpot.Domain.Exception.ExceptionMessages;
using TouristSpot.Domain.Exception;
using Utils.Inputs;
using Utils.AutoMapper;
using Utils.Repositories;

namespace TouristSpot.Application.Test
{
    public class RegisterTouristSpotUseCase
    {
        [Fact]
        public async Task Sucess()
        {
            var useCase = CreateUseCase();
            var input = InputRegisterTouristSpotBuilder.Build();

            var result = await useCase.Execute(input);

            result.Should().NotBeNull();
            result.Name.Should().Be(input.Name);
            result.Description.Should().Be(input.Description);
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var useCase = CreateUseCase();
            var input = InputRegisterTouristSpotBuilder.BuildWithNameEmpty();

            var actionResult = async () => await useCase.Execute(input);
            (await actionResult.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(exception => exception.ErrorsMessages.Count == 1 && exception.ErrorsMessages.Contains(ResourceMessageException.NAME_EMPTY));
        }

        public RegisterTouristSpot CreateUseCase()
        {
            var mapper = MapperBuilder.Build();
            var repository = TouristSpotRepositoryBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var useCase = new RegisterTouristSpot(mapper, repository, unitOfWork);
            return useCase;
        }
    }
}
