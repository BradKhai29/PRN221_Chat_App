using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations;

public class ChatMessageEntityConfiguration : IEntityConfiguration<ChatMessageEntity>
{
    public void Configure(EntityTypeBuilder<ChatMessageEntity> builder)
    {
        builder.ToTable(ChatMessageEntity.MetaData.TableName);

        builder.HasKey(chatMessage => chatMessage.Id);

        // Properties Configuration.
        builder
            .Property(chatMessage => chatMessage.Content)
            .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_MAX)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.Images)
            .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_2000)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.ChatGroupId)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.ReplyMessageId)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.CreatedAt)
            .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.CreatedBy)
            .IsRequired();

        builder
            .Property(chatMessage => chatMessage.UpdatedAt)
            .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
            .IsRequired();

        // Relationships Configuration.
        builder
            .HasOne(chatMesssage => chatMesssage.ChatGroup)
            .WithMany(chatGroup => chatGroup.ChatMessages)
            .HasForeignKey(chatMessage => chatMessage.ChatGroupId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(chatMesssage => chatMesssage.Sender)
            .WithMany(user => user.ChatMessages)
            .HasForeignKey(chatMessage => chatMessage.CreatedBy)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(chatMesssage => chatMesssage.ReplyMessage)
            .WithOne()
            .HasForeignKey<ChatMessageEntity>(chatMessage => chatMessage.ReplyMessageId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}