using Microsoft.AspNetCore.Mvc;
using MikeAndAnt.Api.Models;
using MikeAndAnt.Api.Services;

namespace MikeAndAnt.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : Controller
{
    private readonly ISearchService _searchService;

    public SearchController(ISearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpGet("{departureAirport}/{arrivalAirport}/{departureDate}/{nights}")]
    public async Task<IEnumerable<Package>> Search(
        [FromRoute] string departureAirport,
        [FromRoute] string arrivalAirport,
        [FromRoute] string departureDate,
        [FromRoute] int nights)
    {
        return await _searchService.Search(departureAirport, arrivalAirport, departureDate, nights);
    }
}
