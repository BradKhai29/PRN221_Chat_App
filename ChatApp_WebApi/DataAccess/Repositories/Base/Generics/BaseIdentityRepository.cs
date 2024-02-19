using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Evaluator;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Base.Generics;

public abstract class BaseIdentityRepository<TEntity> :
    IBaseIdentityRepository<TEntity, Guid>
    where TEntity : class, IBaseEntity
{
    private readonly DbSet<TEntity> _dbSet;

    protected BaseIdentityRepository(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }

    public abstract Task<IdentityResult> AddAsync(TEntity newEntity);

    public abstract Task<IdentityResult> RemoveAsync(Guid id);

    public abstract Task<IdentityResult> UpdateAsync(TEntity foundEntity);

    public abstract Task<TEntity> FindByIdAsync(Guid id);

    public abstract Task<TEntity> FindByNameAsync(string name);

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

        return inputQueryable.AnyAsync(
            cancellationToken: cancellationToken);
    }
}
