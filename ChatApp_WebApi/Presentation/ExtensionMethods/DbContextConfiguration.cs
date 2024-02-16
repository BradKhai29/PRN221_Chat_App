using DataAccess.Core;

namespace Presentation.ExtensionMethods
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbContextConfiguration(
            this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            services.AddDbContextPool<ChatAppDbContext>(optionsAction: options =>
            {
    
            });

            return services;
        }
    }
}
