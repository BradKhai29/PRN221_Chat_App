using System.Linq.Expressions;
using DataAccess.Core.Entities.Base;

namespace DataAccess.Specifications.Entities.Base.Generics;

public abstract class GenericSpecification<TEntity> : IGenericSpecification<TEntity>
    where TEntity : class, IBaseEntity
{
    public Expression<Func<TEntity, bool>> Criteria { get; protected set; }

    public Expression<Func<TEntity, object>> OrderByAscendingExpression { get; protected set; }

    public Expression<Func<TEntity, object>> OrderByDescendingExpression { get; protected set; }

    public Expression<Func<TEntity, TEntity>> SelectExpression { get; protected set; }

    public bool IsAsSplitQuery { get; protected set; }

    public bool IsAsNoTracking { get; protected set; }

    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; protected set; }

    public int SkipNumberOfEntities { get; protected set; }

    public int TakeNumberOfEntities { get; protected set; }
}
