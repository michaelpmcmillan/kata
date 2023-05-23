using AutoFixture;
using FluentAssertions;
using MikeAndAnt.Api.Controllers;
using MikeAndAnt.Api.Models;
using MikeAndAnt.Api.Services;
using Moq;
using Moq.AutoMock;

namespace MikeAndAnt.Tests.Controllers;

public class SearchControllerTests
{
    private readonly AutoMocker _mocker = new();
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task WhenSearch_ThenReturnSearchResults()
    {
        // Given
        var arrivalAirport = _fixture.Create<string>();
        var departureAirport = _fixture.Create<string>();
        var departureDate = _fixture.Create<string>();
        var nights = _fixture.Create<int>();
        var searchResults = _fixture.CreateMany<Package>();

        _mocker.GetMock<ISearchService>()
            .Setup(_ => _.Search(arrivalAirport, departureAirport, departureDate, nights))
            .ReturnsAsync(searchResults);

        // When
        var subject = _mocker.CreateInstance<SearchController>();
        var results = await subject.Search(arrivalAirport, departureAirport, departureDate, nights);

        // Then
        results.Should().BeEquivalentTo(searchResults);
    }
}