using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Entities.Base.Generics
{
    public sealed class GenericAsSplitQuerySpecification<TEntity> :
        GenericSpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        public GenericAsSplitQuerySpecification()
        {
            IsAsSplitQuery = true;
        }
    }
}
