namespace Presentation.ExtensionMethods;

public static class WebApiConfiguration
{
    public static IServiceCollection AddWebApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();

        return services;
    }
}
