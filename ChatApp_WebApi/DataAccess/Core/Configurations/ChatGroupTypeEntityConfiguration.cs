using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class ChatGroupTypeEntityConfiguration :
        IEntityConfiguration<ChatGroupTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ChatGroupTypeEntity> builder)
        {
            builder.ToTable(ChatGroupTypeEntity.MetaData.TableName);

            builder.HasKey(groupType => groupType.Id);

            // Properties Configuration.
            builder
                .HasIndex(groupType => groupType.Name)
                .IsUnique();

            builder
                .Property(groupType => groupType.Name)
                .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_20)
                .IsRequired();
        }
    }
}
