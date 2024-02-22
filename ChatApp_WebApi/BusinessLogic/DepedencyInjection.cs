using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Entities.Implementation;
using BusinessLogic.Services.Externals.Base;
using BusinessLogic.Services.Externals.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
    public static class DepedencyInjection
    {
        /// <summary>
        ///     Inject the services from the BusinessLogic layer.
        /// </summary>
        /// <param name="services">Current Service Collection</param>
        /// <returns>
        ///     The current service collection after injecting BusinessLogic layer's services.
        /// </returns>
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddEntityServices();
            services.AddExternalServices();

            return services;
        }

        /// <summary>
        ///     Add the services that interact
        ///     with core-entites to the dependency container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IChatMessageHandlingService, ChatMessageHandlingService>();
            services.AddScoped<IRefreshTokenHandlingService, RefreshTokenHandlingService>();
            services.AddScoped<IAuthHandlingService, AuthHandlingService>();

            return services;
        }

        private static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddScoped<IAccessTokenHandlingService, AccessTokenHandlingService>();
            services.AddScoped<IPasswordHandlingService, PasswordHandlingService>();

            return services;
        }
    }
}