using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class UserTokenEntityConfiguration :
        IEntityConfiguration<UserTokenEntity>
    {
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder.ToTable(UserTokenEntity.MetaData.TableName);

            builder
                .Property(userToken => userToken.ExpiredAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();
        }
    }
}
