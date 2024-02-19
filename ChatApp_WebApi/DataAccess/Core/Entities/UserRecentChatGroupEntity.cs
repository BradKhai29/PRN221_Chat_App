using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class UserRecentChatGroupEntity : IBaseEntity
{
    public Guid UserId { get; set; }

    public Guid ChatGroupId { get; set; }

    public DateTime CreatedAt { get; set; }

        // Navigation Properties
    public UserEntity User { get; set; }

    public ChatGroupEntity ChatGroup { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "UserRecentChatGroups";
    }
    #endregion
}
