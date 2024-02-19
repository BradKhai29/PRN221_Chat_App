using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Entities.Base.Generics
{
    public sealed class GenericAsNoTrackingSpecification<TEntity> :
        GenericSpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        public GenericAsNoTrackingSpecification()
        {
            IsAsNoTracking = true;
        }
    }
}
