using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Presentation.ExtensionMethods
{
    public static class SwaggerConfiguration
    {
        public const string SwaggerDocName = "v1";
        public const string SwaggerDocVersion = "v1";
        private const string SwaggerDocTitle = "ChatApp WebApi";
        private const string SwaggerDocDescription = "The WebApi for Chat App";
        private const string AuthorizationHttpHeader = "Authorization";

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setupAction: options =>
            {
                options.SwaggerDoc(
                    name: SwaggerDocName,
                    info: new()
                    {
                        Version = SwaggerDocVersion,
                        Title = SwaggerDocTitle,
                        Description = SwaggerDocDescription,
                        License = new()
                        {
                            Name = "MIT",
                            Url = new("https://opensource.org/license/mit/")
                        }
                    });

                options.AddSecurityDefinition(
                    name: JwtBearerDefaults.AuthenticationScheme,
                    securityScheme: new()
                    {
                        Description = @"JWT Authorization header using the Bearer scheme.
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: 'Bearer 12345abcdef'",
                        Name = AuthorizationHttpHeader,
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = JwtBearerDefaults.AuthenticationScheme
                    });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                var xmlFilePath = Path.Combine(
                        path1: AppContext.BaseDirectory,
                        path2: xmlFilename);

                options.IncludeXmlComments(filePath: xmlFilePath);
            });

            return services;
        }
    }
}
