using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class RefreshTokenEntityConfiguration :
        IEntityConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.ToTable(RefreshTokenEntity.MetaData.TableName);

            builder.HasKey(token => token.Id);

            // Properties Configuration.
            builder
                .Property(token => token.UserId)
                .IsRequired();

            builder
                .Property(token => token.Value)
                .HasColumnType(SqlDataTypes.NVARCHAR_32)
                .IsRequired();

            builder
                .Property(token => token.AccessTokenId)
                .IsRequired();

            builder
                .Property(token => token.CreatedAt)
                .HasColumnType(SqlDataTypes.DATETIME)
                .IsRequired();

            builder
                .Property(token => token.ExpiredAt)
                .HasColumnType(SqlDataTypes.DATETIME)
                .IsRequired();

            // Relationships Configuration.
            builder
                .HasOne(token => token.User)
                .WithMany(user => user.RefreshTokens)
                .HasForeignKey(token => token.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
