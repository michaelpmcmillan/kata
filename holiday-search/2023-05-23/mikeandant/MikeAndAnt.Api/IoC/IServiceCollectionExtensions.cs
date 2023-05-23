using MikeAndAnt.Api.Services;

namespace MikeAndAnt.Api.IoC;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApi(this IServiceCollection services)
    {
        return services
            .AddSwaggerGen()
            .AddTransient<ISearchService, SearchService>();
    }
}
