using DataAccess.Core.Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Specifications.Entities.Base.Generics.Commons
{
    public interface ISelectSpecification<TEntity>
        where TEntity : class, IBaseEntity
    {
        Expression<Func<TEntity, TEntity>> SelectExpression { get; }
    }
}
