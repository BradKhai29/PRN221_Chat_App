using DataAccess.Commons.SqlConstants;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class UserEntityConfiguration :
        IEntityConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(UserEntity.MetaData.TableName);

            // Properties Configuration.
            builder
                .Property(user => user.AvatarUrl)
                .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_200)
                .HasDefaultValue(DefaultValues.UserAvatarUrl)
                .IsRequired();

            builder
                .Property(user => user.CreatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(user => user.UpdatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(user => user.UpdatedBy)
                .HasDefaultValue(DefaultValues.SystemId)
                .IsRequired();

            builder
                .Property(user => user.RemovedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(user => user.RemovedBy)
                .HasDefaultValue(DefaultValues.SystemId)
                .IsRequired();
        }
    }
}
