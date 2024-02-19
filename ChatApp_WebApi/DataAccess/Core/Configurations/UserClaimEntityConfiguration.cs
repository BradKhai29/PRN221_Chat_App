using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class UserClaimEntityConfiguration :
        IEntityConfiguration<UserClaimEntity>
    {
        public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
        {
            builder.ToTable(UserClaimEntity.MetaData.TableName);
        }
    }
}
