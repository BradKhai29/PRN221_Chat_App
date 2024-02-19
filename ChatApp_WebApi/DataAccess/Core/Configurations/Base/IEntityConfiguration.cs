using DataAccess.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core.Configurations.Base
{
    internal interface IEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IBaseEntity
    {
    }
}
