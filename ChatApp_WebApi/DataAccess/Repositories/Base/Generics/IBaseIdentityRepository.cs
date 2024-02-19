using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Repositories.Base.Generics;

/// <summary>
///     The base interface for all Repository classes
///     that uses IdentityServer as a base to inherit from.
/// </summary>
/// <remarks>
///     This interface does not provide update method. Because the update
///     will be handled by bulk-update for each non-generic repository.
/// </remarks>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TKeyId">
///     The data-type that used by entityId.
/// </typeparam>
public interface IBaseIdentityRepository<TEntity, TKeyId>
    where TEntity: class, IBaseEntity
{

    Task<IdentityResult> AddAsync(TEntity newEntity);

    Task<IdentityResult> UpdateAsync(TEntity foundEntity);

    Task<IdentityResult> RemoveAsync(TKeyId id);

    Task<TEntity> FindByIdAsync(TKeyId id);

    Task<TEntity> FindByNameAsync(string name);

    /// <summary>
    ///     Asynchronously if the entity exist or not
    /// </summary>
    /// <param name="specifications">
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellationToken to notify the system to cancel
    ///     the current operation when user stop the request.
    /// </param>
    /// <returns>
    ///     A task containing boolean result which is
    ///         False if the entity does not exist or
    ///         True if the entity exist
    /// </returns>
    Task<bool> IsFoundBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications);

    Task<IList<TEntity>> GetAllBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications);

    Task<TEntity> FindBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications);
}
