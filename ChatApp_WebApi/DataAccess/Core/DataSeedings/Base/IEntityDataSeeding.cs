using DataAccess.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core.DataSeedings.Base
{
    internal interface IEntityDataSeeding<TEntity> 
        : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseEntity
    {
    }
}
