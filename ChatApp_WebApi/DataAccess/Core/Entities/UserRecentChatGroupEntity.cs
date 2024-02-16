namespace DataAccess.Core.Entities;

public class UserRecentChatGroupEntity
{
    public Guid MemberId { get; set; }

    public Guid ChatGroupId { get; set; }

    public DateTime CreatedAt { get; set; }
}
