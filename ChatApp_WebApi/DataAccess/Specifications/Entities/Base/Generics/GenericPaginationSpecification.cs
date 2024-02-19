using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Entities.Base.Generics;

public sealed class GenericPaginationSpecification<TEntity>
    : GenericSpecification<TEntity>
    where TEntity : class, IBaseEntity
{
    public GenericPaginationSpecification(int skipNumber, int takeNumber)
    {
        SkipNumberOfEntities = skipNumber;

        TakeNumberOfEntities = takeNumber;
    }
}
