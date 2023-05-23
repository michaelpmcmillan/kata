using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace MikeAndAnt.Api.IoC;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app)
    {
        return app
            .UseSwagger()
            .UseSwaggerUI();
    }
}
