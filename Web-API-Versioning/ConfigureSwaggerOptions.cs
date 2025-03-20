using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Web_API_Versioning
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            var addedVersions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"Total API versions detected: {_apiVersionDescriptionProvider.ApiVersionDescriptions.Count}");
            foreach (var item in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                Console.WriteLine($"Found version: GroupName={item.GroupName}, ApiVersion={item.ApiVersion}");
                if (!addedVersions.Add(item.GroupName))
                {
                    Console.WriteLine($"Skipping duplicate API version: {item.GroupName}");
                    continue;
                }

                Console.WriteLine($"Adding API version: {item.GroupName}");
                options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "Your Versioned API",
                Version = description.ApiVersion.ToString(),
                Description = "API versioning with Swagger",
                Contact = new OpenApiContact
                {
                    Name = "Your Name",
                    Email = "your-email@example.com",
                    Url = new Uri("https://your-website.com")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            };
        }
    }
}