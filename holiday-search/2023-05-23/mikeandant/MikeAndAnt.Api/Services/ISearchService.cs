using MikeAndAnt.Api.Models;

namespace MikeAndAnt.Api.Services;

public interface ISearchService
{
    Task<IEnumerable<Package>> Search(string from, string to, string departureDate, int nights);
}
