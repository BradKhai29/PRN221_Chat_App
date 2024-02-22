using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations
{
    internal class ChatGroupMemberEntityConfiguration :
        IEntityConfiguration<ChatGroupMemberEntity>
    {
        public void Configure(EntityTypeBuilder<ChatGroupMemberEntity> builder)
        {
            builder.ToTable(name: ChatGroupMemberEntity.MetaData.TableName);

            builder.HasKey(keyExpression: chatGroupMember => new
            {
                chatGroupMember.MemberId,
                chatGroupMember.ChatGroupId,
            });

            // Properties Configuration
            builder
                .Property(chatGroupMember => chatGroupMember.CreatedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            builder
                .Property(chatGroupMember => chatGroupMember.LastAccessedAt)
                .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
                .IsRequired();

            // Relationships Configuration
            builder
                .HasOne(navigationExpression: chatGroupMember => chatGroupMember.Member)
                .WithMany(navigationExpression: member => member.ChatGroupMembers)
                .HasForeignKey(foreignKeyExpression: chatGroupMember => chatGroupMember.MemberId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
                .HasOne(navigationExpression: chatGroupMember => chatGroupMember.ChatGroup)
                .WithMany(navigationExpression: chatGroup => chatGroup.ChatGroupMembers)
                .HasForeignKey(foreignKeyExpression: chatGroupMember => chatGroupMember.ChatGroupId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
                .HasOne(navigationExpression: chatGroupMember => chatGroupMember.Role)
                .WithMany(navigationExpression: chatGroup => chatGroup.ChatGroupMembers)
                .HasForeignKey(foreignKeyExpression: chatGroupMember => chatGroupMember.RoleId)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        }
    }
}
