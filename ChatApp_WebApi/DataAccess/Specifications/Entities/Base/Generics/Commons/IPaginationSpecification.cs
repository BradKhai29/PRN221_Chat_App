using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Entities.Base.Generics.Commons
{
    public interface IPaginationSpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        int SkipNumberOfEntities { get; }

        int TakeNumberOfEntities { get; }
    }
}
