using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class AccountStatusEntityConfiguration :
        IEntityConfiguration<AccountStatusEntity>
    {
        public void Configure(EntityTypeBuilder<AccountStatusEntity> builder)
        {
            builder.ToTable(AccountStatusEntity.MetaData.TableName);

            builder.HasKey(status => status.Id);

            builder
                .Property(status => status.Name)
                .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_20)
                .IsRequired();

            builder
                .HasIndex(status => status.Name)
                .IsUnique();

            // Relationships Configuration.
            builder
                .HasMany(status => status.Users)
                .WithOne(user => user.AccountStatus)
                .HasPrincipalKey(status => status.Id)
                .HasForeignKey(user => user.AccountStatusId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
