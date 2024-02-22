using DataAccess.Commons.SqlConstants;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Configurations.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.Configurations;

internal class ChatGroupEntityConfiguration :
    IEntityConfiguration<ChatGroupEntity>
{
    public void Configure(EntityTypeBuilder<ChatGroupEntity> builder)
    {
        builder.ToTable(name: ChatGroupEntity.MetaData.TableName);

        builder.HasKey(keyExpression: chatGroup => chatGroup.Id);
        
        // Properties Configuration,
        builder
            .Property(chatGroup => chatGroup.Name)
            .HasColumnType(SqlDataTypes.SqlServer.NVARCHAR_200)
            .IsRequired();

        builder
            .Property(chatGroup => chatGroup.ChatGroupTypeId)
            .IsRequired();

        builder
            .Property(chatGroup => chatGroup.CreatedAt)
            .HasColumnType(SqlDataTypes.SqlServer.DATETIME)
            .IsRequired();

        builder
            .Property(chatGroup => chatGroup.CreatedBy)
            .HasDefaultValue(DefaultValues.SystemId)
            .IsRequired();

        // Relationships Configuration
        builder
            .HasOne(chatGroup => chatGroup.Creator)
            .WithMany(creator => creator.CreatedChatGroups)
            .HasForeignKey(chatGroup => chatGroup.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(chatGroup => chatGroup.ChatGroupType)
            .WithMany(groupType => groupType.ChatGroups)
            .HasForeignKey(chatGroup => chatGroup.ChatGroupTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(chatGroup => chatGroup.ChatMessages)
            .WithOne(chatMessage => chatMessage.ChatGroup)
            .HasPrincipalKey(chatGroup => chatGroup.Id)
            .HasForeignKey(message => message.ChatGroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
