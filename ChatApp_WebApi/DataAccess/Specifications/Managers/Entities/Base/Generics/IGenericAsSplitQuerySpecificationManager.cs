using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base.Generics
{
    public interface IGenericAsSplitQuerySpecificationManager<TEntity>
        where TEntity : class, IBaseEntity
    {
        GenericAsSplitQuerySpecification<TEntity> AsSplitQuery { get; }
    }
}
