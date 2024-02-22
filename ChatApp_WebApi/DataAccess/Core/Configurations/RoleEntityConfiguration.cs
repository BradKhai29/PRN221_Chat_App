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

            // Properties Configuraiton.
            builder
                .Property(role => role.Name)
                .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_50)
                .IsRequired();

            builder
                .HasIndex(role => role.Name)
                .IsUnique();

            builder
                .Property(role => role.CreatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(role => role.CreatedBy)
                .HasDefaultValue(DefaultValues.SystemId)
                .IsRequired();
        }
    }
}
