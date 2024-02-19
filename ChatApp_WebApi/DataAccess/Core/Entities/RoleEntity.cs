using DataAccess.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Core.Entities;

public class RoleEntity :
    IdentityRole<Guid>,
    IGuidEntity,
    ICreatedEntity
{
    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    // Navigation Properties
    public UserEntity Creator { get; set; }

    public IEnumerable<ChatGroupMemberEntity> ChatGroupMembers { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "Roles";
    }
    #endregion
}
