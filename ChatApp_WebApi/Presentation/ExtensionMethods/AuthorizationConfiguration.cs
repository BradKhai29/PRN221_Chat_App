namespace Presentation.ExtensionMethods
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection AddAuthorizationConfiguration(
            this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            return services;
        }
    }
}
