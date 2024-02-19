using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Entities.Base.Generics.Commons;
using System.Linq.Expressions;

namespace DataAccess.Specifications.Entities.Base.Generics;

public interface IGenericSpecification<TEntity> :
    IWhereSpecification<TEntity>,
    ISelectSpecification<TEntity>,
    IOrderBySpecification<TEntity>,
    IPaginationSpecification<TEntity>
    where TEntity : class, IBaseEntity
{
    bool IsAsSplitQuery { get; }

    bool IsAsNoTracking { get; }

    List<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
}
