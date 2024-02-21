using Microsoft.AspNetCore.Authentication.JwtBearer;
using Presentation.Models.Options;
using Presentation.OptionsSetup;

namespace Presentation.ExtensionMethods
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddAuthenticationConfiguration(
            this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            var _jwtOptions = JwtOptions.Bind(configurationManager);

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _jwtOptions.Issuer,
                        ValidAudience = _jwtOptions.Audience,
                        IssuerSigningKey = _jwtOptions.GetSecurityKey()
                    };
                });

            return services;
        }
    }
}
