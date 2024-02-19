using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class RoleClaimEntityConfiguration :
        IEntityConfiguration<RoleClaimEntity>
    {
        public void Configure(EntityTypeBuilder<RoleClaimEntity> builder)
        {
            builder.ToTable(RoleClaimEntity.MetaData.TableName);
        }
    }
}
