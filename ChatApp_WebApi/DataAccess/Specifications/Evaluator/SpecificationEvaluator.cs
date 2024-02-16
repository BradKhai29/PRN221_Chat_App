using DataAccess.Core.Entities.Base;
using DataAccess.Specifications.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Specifications.Evaluator;

public class SpecificationEvaluator
{
    public static IQueryable<TEntity> ApplySpecifications<TEntity>(
        IQueryable<TEntity> inputQueryable,
        params IGenericSpecification<TEntity>[] specifications)
            where TEntity : class, IBaseEntity
    {
        Array.ForEach(
            array: specifications,
            action: specification =>
            {
                inputQueryable = InternalApplySpecifications(
                    inputQueryable: inputQueryable,
                    specification: specification);
            });

        return inputQueryable;
    }

    private static IQueryable<TEntity> InternalApplySpecifications<TEntity>(
        IQueryable<TEntity> inputQueryable,
        IGenericSpecification<TEntity> specification)
        where TEntity : class, IBaseEntity
    {
        if (specification.IncludeExpressions is not null)
        {
            inputQueryable = specification.IncludeExpressions.Aggregate(
                seed: inputQueryable,
                func: (queryable, includeExpression) =>
                    queryable.Include(navigationPropertyPath: includeExpression)
            );
        }

        if (specification.OrderByAscendingExpression is not null)
        {
            inputQueryable = inputQueryable.OrderBy(
                keySelector: specification.OrderByAscendingExpression);
        }

        if (specification.OrderByDescendingExpression is not null)
        {
            inputQueryable = inputQueryable.OrderByDescending(
                keySelector: specification.OrderByDescendingExpression);
        }

        if (specification.Criteria is not null)
        {
            inputQueryable = inputQueryable.Where(
                predicate: specification.Criteria);
        }

        if (specification.SelectExpression is not null)
        {
            inputQueryable = inputQueryable.Select(
                selector: specification.SelectExpression);
        }

        if (specification.IsAsNoTracking)
        {
            inputQueryable = inputQueryable.AsNoTracking();
        }

        if (specification.IsAsSplitQuery)
        {
            inputQueryable = inputQueryable.AsSplitQuery();
        }

        if (specification.SkipNumberOfEntities > default(int))
        {
            inputQueryable = inputQueryable.Skip(
                count: specification.SkipNumberOfEntities);
        }

        if (specification.TakeNumberOfEntities > default(int))
        {
            inputQueryable = inputQueryable.Take(
                count: specification.TakeNumberOfEntities);
        }

        return inputQueryable;
    }
}
