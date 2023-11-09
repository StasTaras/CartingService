using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CartingService.Utils.Swagger
{
    public class SwaggerOptions
    {
        public static Action<SwaggerGenOptions> GetSwaggerGenOptions(IServiceCollection services)
        {
            return options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo()
                        {
                            Title = $"{Assembly.GetExecutingAssembly().GetName().Name} {description.ApiVersion}",
                            Version = description.ApiVersion.ToString()
                        });

                }
            };
        }
    }
}
