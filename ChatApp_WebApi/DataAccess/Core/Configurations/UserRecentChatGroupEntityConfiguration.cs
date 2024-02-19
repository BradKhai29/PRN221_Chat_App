using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class UserRecentChatGroupEntityConfiguration :
        IEntityConfiguration<UserRecentChatGroupEntity>
    {
        public void Configure(EntityTypeBuilder<UserRecentChatGroupEntity> builder)
        {
            builder.ToTable(UserRecentChatGroupEntity.MetaData.TableName);

            builder.HasKey(userRecentChatGroup => new
            {
                userRecentChatGroup.UserId,
                userRecentChatGroup.ChatGroupId
            });

            // Properties Configuration.
            builder
                .Property(userRecentChatGroup => userRecentChatGroup.CreatedAt)
                .HasColumnType(SqlDataTypes.DATETIME)
                .IsRequired();

            // Relationships Configuration.
            builder
                .HasOne(userRecentChatGroup => userRecentChatGroup.User)
                .WithOne(user => user.UserRecentChatGroup)
                .HasPrincipalKey<UserEntity>(user => user.Id)
                .HasForeignKey<UserRecentChatGroupEntity>(userRecentChatGroup => userRecentChatGroup.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(userRecentChatGroup => userRecentChatGroup.ChatGroup)
                .WithMany(chatGroup => chatGroup.UserRecentChatGroups)
                .HasForeignKey(userRecentChatGroup => userRecentChatGroup.ChatGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
