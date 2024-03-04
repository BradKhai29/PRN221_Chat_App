using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base.Generics
{
    public interface IGenericAsNoTrackingSpecificationManager<TEntity>
        where TEntity : class, IBaseEntity
    {
        GenericAsNoTrackingSpecification<TEntity> AsNoTracking { get; }
    }
}
