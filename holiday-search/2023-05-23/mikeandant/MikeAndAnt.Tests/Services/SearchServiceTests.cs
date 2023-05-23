using AutoFixture;
using FluentAssertions;
using MikeAndAnt.Api.Services;
using Moq.AutoMock;

namespace MikeAndAnt.Tests.Services;

public class SearchServiceTests
{
    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    [Theory]
    [InlineData("MAN", "AGP", "20230701", 7, 2, 9)]
    [InlineData("LON", "PMI", "20230615", 10, 6, 5)]
    public async Task WhenSearch_ThenReturnExpectedFlightAndHotel(
        string departureAirport, string arrivalAirport, string departureDate, int nights,
        int expectedFlight, int expectedHotel)
    {
        // When
        var subject = _mocker.CreateInstance<SearchService>();
        var results = await subject.Search(departureAirport, arrivalAirport, departureDate, nights);

        // Then
        results.Count().Should().Be(1);
        results.Single().Flight.Id.Should().Be(expectedFlight);
        results.Single().Hotel.Id.Should().Be(expectedHotel);
    }
}
