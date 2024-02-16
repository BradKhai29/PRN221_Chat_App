using System.Linq.Expressions;
using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Base.Generics;

public interface IGenericSpecification<TEntity>
    where TEntity : class, IBaseEntity
{
    Expression<Func<TEntity, bool>> Criteria { get; }

    Expression<Func<TEntity, object>> OrderByAscendingExpression { get; }

    Expression<Func<TEntity, object>> OrderByDescendingExpression { get; }

    Expression<Func<TEntity, TEntity>> SelectExpression { get; }

    bool IsAsSplitQuery { get; }

    bool IsAsNoTracking { get; }

    List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }

    int SkipNumberOfEntities { get; }

    int TakeNumberOfEntities { get; }
}
