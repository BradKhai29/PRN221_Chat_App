using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base.Generics
{
    public interface IGenericPaginationSpecificationManager<TEntity>
        where TEntity : class, IBaseEntity
    {
        GenericPaginationSpecification<TEntity> Pagination(int skipNumber, int takeNumber);
    }
}
