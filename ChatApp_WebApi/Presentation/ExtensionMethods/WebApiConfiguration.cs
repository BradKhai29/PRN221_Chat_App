﻿using Microsoft.IdentityModel.Protocols;
using Presentation.ChatHub.ChatConnection;

namespace Presentation.ExtensionMethods;

public static class WebApiConfiguration
{
    public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigCors();
        services.ConfigureLogging();
        services.AddSignalRConfiguration();
        return services;
    }
    /// <summary>
    ///     Configure the logging service.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    private static void ConfigureLogging(this IServiceCollection services)
    {
        services.AddLogging(configure: config =>
        {
            config.ClearProviders();
            config.AddConsole();
        });
    }

    /// <summary>
    /// Configures CORS for the web API.
    /// </summary>
    /// <param name="services">The IServiceCollection instance.</param>
    private static void ConfigCors(this IServiceCollection services)
    {
        services.AddCors(setupAction: config =>
        {
            config.AddDefaultPolicy(configurePolicy: policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
    private static void AddSignalRConfiguration(this IServiceCollection services)
    {
        services.AddSignalR().AddHubOptions<Chat>(
            options => options.MaximumParallelInvocationsPerClient = 5);
    }
}
