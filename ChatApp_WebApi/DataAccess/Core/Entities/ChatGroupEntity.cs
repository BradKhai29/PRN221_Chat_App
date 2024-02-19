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

    public UserEntity Creator { get; set; }

    public IEnumerable<ChatMessageEntity> ChatMessages { get; set; }

    public IEnumerable<UserRecentChatGroupEntity> UserRecentChatGroups { get; set; }

    public IEnumerable<ChatGroupMemberEntity> ChatGroupMembers { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "ChatGroups";
    }
    #endregion
}
