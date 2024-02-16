using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class ChatGroupEntity : 
    GuidEntity,
    ICreatedEntity
{
    public string Name { get; set; }

    public Guid ChatGroupTypeId { get; set; }

    public bool IsPrivate { get; set; }

    public int MemberCount { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    // Navigation Properties
    public ChatGroupTypeEntity ChatGroupType { get; set; }

    public IList<ChatMessageEntity> ChatMessages { get; set; }

    public IList<UserRecentChatGroupEntity> UserRecentChatGroups { get; set; }

    public IList<ChatGroupMemberEntity> ChatGroupMembers { get; set; }
}
