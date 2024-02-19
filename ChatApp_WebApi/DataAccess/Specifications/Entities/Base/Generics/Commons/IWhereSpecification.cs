using DataAccess.Core.Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Specifications.Entities.Base.Generics.Commons
{
    public interface IWhereSpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
    }
}
