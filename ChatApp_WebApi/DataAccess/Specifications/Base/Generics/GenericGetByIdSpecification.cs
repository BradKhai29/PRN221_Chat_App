using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Base.Generics;

public abstract class GenericGetByIdSpecification<TEntity>
    : GenericSpecification<TEntity>
    where TEntity : class, IGuidEntity
{
    public GenericGetByIdSpecification(Guid id)
    {
        Criteria = entity => entity.Id.Equals(id);
    }
}
