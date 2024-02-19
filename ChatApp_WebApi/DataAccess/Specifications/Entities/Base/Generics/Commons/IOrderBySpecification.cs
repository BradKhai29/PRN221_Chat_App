using DataAccess.Core.Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Specifications.Entities.Base.Generics.Commons
{
    public interface IOrderBySpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        Expression<Func<TEntity, object>> OrderByAscendingExpression { get; }

        Expression<Func<TEntity, object>> OrderByDescendingExpression { get; }
    }
}
