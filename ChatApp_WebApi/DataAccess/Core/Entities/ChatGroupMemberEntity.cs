using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class ChatGroupMemberEntity : IBaseEntity
{
    public Guid MemberId { get; set; }

    public Guid ChatGroupId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastAccessedAt { get; set; }

    // Navigation Properties
    public UserEntity Member { get; set; }

    public ChatGroupEntity ChatGroup { get; set; }

    public RoleEntity Role { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "ChatGroupMembers";
    }
    #endregion
}
