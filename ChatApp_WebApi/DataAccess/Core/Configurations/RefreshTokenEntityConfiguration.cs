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

            // Token value configuration.
            builder
                .Property(token => token.Value)
                .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_32)
                .IsRequired();

            builder
                .HasIndex(token => token.Value)
                .IsClustered(clustered: false)
                .IsUnique();

            // AccessTokenId configuration.
            builder
                .Property(token => token.AccessTokenId)
                .IsRequired();

            builder
                .HasIndex(token => token.AccessTokenId)
                .IsClustered(clustered: false)
                .IsUnique();

            builder
                .Property(token => token.CreatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(token => token.ExpiredAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
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
