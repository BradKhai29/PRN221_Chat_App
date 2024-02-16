namespace Presentation.ExtensionMethods;

public static class WebApiConfiguration
{
    public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.ConfigureSwagger();

        return services;
    }

    private static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        return services;
    }
}
