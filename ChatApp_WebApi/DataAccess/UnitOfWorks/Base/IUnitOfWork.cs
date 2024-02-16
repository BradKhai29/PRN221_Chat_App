using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWorks.Base;

/// <summary>
///     The base interface to implement the UnitOfWork
/// </summary>
/// <typeparam name="TContext">
///     The context class that used to work with the database.
/// </typeparam>
public interface IUnitOfWork<TContext> : ITransactionHandler
    where TContext : class
{
    TContext DbContext { get; }

    IExecutionStrategy CreateExecutionStrategy();

    Task SaveChangesToDatabaseAsync(CancellationToken cancellationToken);
}