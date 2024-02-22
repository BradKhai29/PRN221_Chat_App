using DataAccess.Core.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.DataSeedings.Base;

internal abstract class EntityDataSeeding<TEntity> : IEntityDataSeeding<TEntity>
    where TEntity : class, IBaseEntity
{
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);

    protected abstract List<TEntity> GetSeedEntities();
}
