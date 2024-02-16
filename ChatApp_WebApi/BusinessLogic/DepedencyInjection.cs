using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Entities.Implementations;
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
            services.AddScoped<IChatMessageHandlingService, ChatMessageHandlingService>();

            return services;
        }
    }
}