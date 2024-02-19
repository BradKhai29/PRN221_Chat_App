using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Evaluator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories.Base.Generics;

public abstract class GenericRepository<TEntity>
    : IGenericRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public ValueTask<EntityEntry<TEntity>> AddAsync(
        TEntity newEntity,
        CancellationToken cancellationToken)
    {
        return _dbSet.AddAsync(
            entity: newEntity,
            cancellationToken: cancellationToken);
    }

    public Task AddRangeAsync(
        IEnumerable<TEntity> newEntities,
        CancellationToken cancellationToken)
    {
        return _dbSet.AddRangeAsync(
            entities: newEntities,
            cancellationToken: cancellationToken);
    }

    public Task<TEntity> FindBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications)
    {
        var inputQueryable = SpecificationEvaluator.ApplySpecifications(
            inputQueryable: _dbSet,
            specifications: specifications);

        return inputQueryable.FirstOrDefaultAsync(
            cancellationToken: cancellationToken);
    }

    public async Task<IList<TEntity>> GetAllBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications)
    {
        var inputQueryable = SpecificationEvaluator.ApplySpecifications(
            inputQueryable: _dbSet,
            specifications: specifications);

        return await inputQueryable.ToListAsync(
            cancellationToken: cancellationToken);
    }

    public Task<bool> IsFoundBySpecificationsAsync(
        CancellationToken cancellationToken,
        params IGenericSpecification<TEntity>[] specifications)
    {
        var inputQueryable = SpecificationEvaluator.ApplySpecifications(
            inputQueryable: _dbSet,
            specifications: specifications);

        return inputQueryable.AnyAsync(cancellationToken: cancellationToken);
    }

    public void Remove(TEntity foundEntity)
    {
        _dbSet.Remove(foundEntity);
    }
}
