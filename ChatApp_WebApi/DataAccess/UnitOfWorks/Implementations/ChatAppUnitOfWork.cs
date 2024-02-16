using DataAccess.Core;
using DataAccess.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWorks.Implementations;

public class ChatAppUnitOfWork : IUnitOfWork<ChatAppDbContext>
{
    // Backing fields
    private readonly ChatAppDbContext _dbContext;
    private IDbContextTransaction _dbTransaction;

    public ChatAppDbContext DbContext => _dbContext;

    public ChatAppUnitOfWork(ChatAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _dbContext.Database.CreateExecutionStrategy();
    }

    public async Task CreateTransactionAsync(CancellationToken cancellationToken)
    {
        _dbTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.CommitAsync(cancellationToken);
    }

    public ValueTask DisposeTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.DisposeAsync();
    }

    public Task RollBackTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.RollbackAsync(cancellationToken);
    }

    public Task SaveChangesToDatabaseAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}