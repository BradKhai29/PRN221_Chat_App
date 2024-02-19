using DataAccess.Core;
using Microsoft.EntityFrameworkCore;

namespace Presentation.ExtensionMethods
{
    public static class DbContextConfiguration
    {
        private const string SectionName = "ChatApp";

        public static IServiceCollection AddDbContextConfiguration(
            this IServiceCollection services,
            ConfigurationManager configurationManager)
        {
            services.AddScoped<DbContext, ChatAppDbContext>();
            services.AddDbContextPool<ChatAppDbContext>(optionsAction: options =>
            {
                var connectionString = configurationManager.GetConnectionString(SectionName);

                options.UseSqlServer(connectionString);
                options.UseLoggerFactory(GetLoggerFactory());
            });

            return services;
        }

        private static ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddLogging(builder =>
            {
                builder
                    .AddConsole()
                    .AddFilter(
                        category: DbLoggerCategory.Database.Command.Name,
                        level: LogLevel.Information);
            });

            return services.BuildServiceProvider().GetService<ILoggerFactory>();
        }
    }
}
