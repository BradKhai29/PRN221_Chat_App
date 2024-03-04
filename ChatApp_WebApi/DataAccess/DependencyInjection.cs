using DataAccess.Core;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Implementation;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.Specifications.Managers.SuperManager.Implementation;
using DataAccess.UnitOfWorks.Base;
using DataAccess.UnitOfWorks.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DependencyInjection
{
    /// <summary>
    ///     Inject the services from the DataAccess layer.
    /// </summary>
    /// <param name="services">Current Service Collection</param>
    /// <returns>
    ///     The current service collection after injecting DataAccess layer's services.
    /// </returns>
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<ISuperSpecificationManager, SuperSpecificationManager>();
        services.AddScoped<IUnitOfWork<ChatAppDbContext>, ChatAppUnitOfWork<ChatAppDbContext>>();

        return services;
    }
}
