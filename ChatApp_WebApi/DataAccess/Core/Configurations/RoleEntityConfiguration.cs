using DataAccess.Commons.SqlConstants;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class RoleEntityConfiguration : IEntityConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable(RoleEntity.MetaData.TableName);

            builder
                .Property(role => role.CreatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(role => role.CreatedBy)
                .HasDefaultValue(DefaultValues.SystemId)
                .IsRequired();

            // Relationships Configuration
            builder
                .HasOne(role => role.Creator)
                .WithMany(user => user.CreatedRoles)
                .HasForeignKey(role => role.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
