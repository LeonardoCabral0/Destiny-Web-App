using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using TouristSpot.Domain.Exception.ExceptionMessages;
using Utils.Inputs;

namespace IntegrationTests
{
    public class RegisterTouristSpotTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public RegisterTouristSpotTest(CustomWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Sucess()
        {
            var request = InputRegisterTouristSpotBuilder.Build();
            var response = await _httpClient.PostAsJsonAsync("touristSpot", request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);


            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);
            responseData.RootElement.GetProperty("name")
                .GetString().Should()
                .NotBeNullOrWhiteSpace()
                .And.Be(request.Name);
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = InputRegisterTouristSpotBuilder.BuildWithNameEmpty();
            var response = await _httpClient.PostAsJsonAsync("touristSpot", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);


            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

            errors.Should().ContainSingle().And.Contain(error => error.GetString().Equals(ResourceMessageException.NAME_EMPTY));
        }

        [Fact]
        public async Task Error_Description_Greater_Than_Max_Size()
        {
            var request = InputRegisterTouristSpotBuilder.BuildDescriptionGreaterThanMaxSize();
            var response = await _httpClient.PostAsJsonAsync("touristSpot", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);


            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

            errors.Should().ContainSingle().And.Contain(error => error.GetString().Equals(ResourceMessageException.DESCRIPTION_MAX_LENGTH));
        }

        [Fact]
        public async Task Error_All_Propertys_Empty()
        {
            var request = InputRegisterTouristSpotBuilder.BuildWithAllPropertysEmpty();
            var response = await _httpClient.PostAsJsonAsync("touristSpot", request);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);


            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

            errors.Should().HaveCount(5);
            errors.Should().Contain(error => error.GetString().Equals(ResourceMessageException.NAME_EMPTY));
            errors.Should().Contain(error => error.GetString().Equals(ResourceMessageException.DESCRIPTION_EMPTY));
            errors.Should().Contain(error => error.GetString().Equals(ResourceMessageException.LOCALIZATION_EMPTY));
            errors.Should().Contain(error => error.GetString().Equals(ResourceMessageException.CITY_EMPTY));
            errors.Should().Contain(error => error.GetString().Equals(ResourceMessageException.STATE_EMPTY));
        }
    }
}
