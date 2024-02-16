namespace DataAccess.Core.Entities;

public class ChatGroupMemberEntity
{
    public Guid MemberId { get; set; }

    public Guid ChatGroupId { get; set; }

    public DateTime CreatedAt { get; set; }
}
