using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories.Base.Generics;

/// <summary>
///     The base interface for all Repository classes to inherit from.
/// </summary>
/// <remarks>
///     This interface does not provide update method. Because the update
///     will be handled by bulk-update for each non-generic repository.
/// </remarks>
/// <typeparam name="TEntity"></typeparam>
public interface IGenericRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    /// <summary>
    ///     Asynchronously change the state of entity to
    ///     <seealso cref="EntityState.Added"/>.
    /// </summary>
    /// <param name="newEntity">
    ///     The entity for adding to the database.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellationToken to notify the system to cancel
    ///     the current operation when user stop the request.
    /// </param>
    /// <returns>
    ///     A value task containing the entity entry of the added entity.
    /// </returns>
    /// <remarks>
    ///     This operation only change the state of the entity and entity will
    ///     not be added to the database until
    ///     <seealso cref="ChatAppUnitOfWork.Contracts.IUnitOfWork{TContext}.SaveToDatabaseAsync(CancellationToken)">
    ///     SaveToDatabaseAsync</seealso> method is called.
    /// </remarks>
    ValueTask<EntityEntry<TEntity>> AddAsync(
        TEntity newEntity,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously change the state list of entities to
    ///     <seealso cref="EntityState.Added"/>.
    /// </summary>
    /// <param name="newEntities">
    ///     List of entities for adding to the database.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellationToken to notify the system to cancel
    ///     the current operation when user stop the request.
    /// </param>
    /// <returns>
    ///     A task representing the operations.
    /// </returns>
    /// <remarks>
    ///     This operation only change the state of the entity and entity will
    ///     not be added to the database until
    ///     <seealso cref="ChatAppUnitOfWork.Contracts.IUnitOfWork{TContext}.SaveToDatabaseAsync(CancellationToken)">
    ///     SaveToDatabaseAsync</seealso> method is called.
    /// </remarks>
    Task AddRangeAsync(
        IEnumerable<TEntity> newEntities,
        CancellationToken cancellationToken);

    /// <summary>
    ///     Asynchronously change the state of entity to
    ///     <seealso cref="EntityState.Deleted"/>.
    /// </summary>
    /// <param name="foundEntity">
    ///     The entity for deleting from the database.
    /// </param>
    /// <remarks>
    ///     This operation only change the state of the entity and entity will
    ///     not be added to the database until
    ///     <seealso cref="ChatAppUnitOfWork.Contracts.IUnitOfWork{TContext}.SaveToDatabaseAsync(CancellationToken)">
    ///     SaveToDatabaseAsync</seealso> method is called.
    /// </remarks>
    void Remove(TEntity foundEntity);

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

    Task<IEnumerable<TEntity>> GetAllBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications);

    Task<TEntity> FindBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications);
}
