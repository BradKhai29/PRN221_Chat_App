using DataAccess.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Core.Entities;

public class UserEntity :
    IdentityUser<Guid>,
    IGuidEntity,
    IUpdatedEntity,
    ITemporarilyRemovedEntity
{
    public string AvatarUrl { get; set; }

    public bool Gender { get; set; }

    public Guid AccountStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime RemovedAt { get; set; }
    
    public Guid RemovedBy { get; set; }
    
    // Navigation Properties
    public AccountStatusEntity AccountStatus { get; set; }

    public UserRecentChatGroupEntity UserRecentChatGroup { get; set; }

    /// <summary>
    ///     Represent the list of chat groups that 
    ///     the current user has joined.
    /// </summary>
    public IEnumerable<ChatGroupMemberEntity> ChatGroupMembers { get; set; }

    /// <summary>
    ///     Represent the list of chat groups that 
    ///     the current user has created.
    /// </summary>
    public IEnumerable<ChatGroupEntity> CreatedChatGroups { get; set; }

    /// <summary>
    ///     Represent the list of chat messages that 
    ///     the current user has sent.
    /// </summary>
    public IEnumerable<ChatMessageEntity> ChatMessages { get; set; }

    /// <summary>
    ///     Represent the list of roles that 
    ///     the current user has created.
    /// </summary>
    public IEnumerable<RoleEntity> CreatedRoles { get; set; }

    /// <summary>
    ///     Represent the list of refresh tokens that 
    ///     the current user has.
    /// </summary>
    public IEnumerable<RefreshTokenEntity> RefreshTokens { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "Users";
    }
    #endregion
}
