using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace IntegrationTests
{
    public class GetTouristSpotTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public object InputGetTouristSpotBuilder { get; private set; }

        public GetTouristSpotTest(CustomWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Sucess()
        {
            var response = await _httpClient.GetAsync("touristSpot");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(10);
        }

        [Fact]
        public async Task Pagination_With_5_TouristsSpots()
        {
            var response = await _httpClient.GetAsync("touristSpot?pageSize=5");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(5).And.Contain(touristSpot => touristSpot.GetProperty("id").GetInt32().Equals(1));
        }

        [Fact]
        public async Task Pagination_Page_2_TouristsSpots()
        {
            var response = await _httpClient.GetAsync("touristSpot?page=2");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(10).And.Contain(touristSpot => touristSpot.GetProperty("id").GetInt32().Equals(20));
        }

        [Fact]
        public async Task Filter_TouristsSpots_By_Name_Returns_Single_Result()
        {
            var response = await _httpClient.GetAsync("touristSpot?searchWord=Parque das Ave");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(1).And.Contain(touristSpot => touristSpot.GetProperty("name").GetString().Equals("Parque das Aves"));
        }

        [Fact]
        public async Task Filter_TouristsSpots_By_Name_Returns_Multiple_Results()
        {
            var response = await _httpClient.GetAsync("touristSpot?searchWord=Parque");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(3)
                .And.Contain(touristSpot => touristSpot.GetProperty("name").GetString().Equals("Parque das Aves"))
                .And.Contain(touristSpot => touristSpot.GetProperty("name").GetString().Equals("Parque Ecológico Verde"))
                .And.Contain(touristSpot => touristSpot.GetProperty("name").GetString().Equals("Parque das Montanhas"));
        }

        [Fact]
        public async Task Filter_TouristsSpots_By_Description_Returns_Single_Result()
        {
            var response = await _httpClient.GetAsync("touristSpot?searchWord=Praia com águas cristalinas.");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(1).And.Contain(touristSpot => touristSpot.GetProperty("description").GetString().Equals("Praia com águas cristalinas."));
        }

        [Fact]
        public async Task Filter_TouristsSpots_By_Description_Returns_Multiple_Results()
        {
            var response = await _httpClient.GetAsync("touristSpot?searchWord=histórica");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(2)
                .And.Contain(touristSpot => touristSpot.GetProperty("description").GetString().Equals("Ruínas históricas."))
                .And.Contain(touristSpot => touristSpot.GetProperty("description").GetString().Equals("Fortaleza histórica do século XVIII."));

        }

        [Fact]
        public async Task Filter_TouristsSpots_By_Description_And_Name_And_Localiaztion_Returns_Multiple_Results()
        {
            var response = await _httpClient.GetAsync("touristSpot?searchWord=Praia");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();
            touristsSpots.Should().HaveCount(3)
                .And.Contain(touristSpot => touristSpot.GetProperty("name").GetString().Equals("Praia do Sol"))
                .And.Contain(touristSpot => touristSpot.GetProperty("localization").GetString().Equals("Praia Grande"))
                .And.Contain(touristSpot => touristSpot.GetProperty("localization").GetString().Equals("Praia do Norte"))
                .And.Contain(touristSpot => touristSpot.GetProperty("description").GetString().Equals("Praia com águas cristalinas."));
        }

        [Fact]
        public async Task Order_Date_Ascending()
        {
            var response = await _httpClient.GetAsync("touristSpot");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();

            var firstDate = touristsSpots.First().GetProperty("createdDate").GetDateTime();
            var lastDate = touristsSpots.Last().GetProperty("createdDate").GetDateTime();

            lastDate.Should().BeAfter(firstDate);
        }

        [Fact]
        public async Task Order_Date_Descending()
        {
            var response = await _httpClient.GetAsync("touristSpot?orderBy=DESC");

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var touristsSpots = responseData.RootElement.GetProperty("touristsSpots").EnumerateArray();

            var firstDate = touristsSpots.First().GetProperty("createdDate").GetDateTime();
            var lastDate = touristsSpots.Last().GetProperty("createdDate").GetDateTime();

            lastDate.Should().BeBefore(firstDate);
        }
    }
}
