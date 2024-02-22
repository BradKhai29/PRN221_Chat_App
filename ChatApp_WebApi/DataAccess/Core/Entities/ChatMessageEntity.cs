using DataAccess.Core.Entities.Base;

namespace DataAccess.Core.Entities;

public class ChatMessageEntity : 
    GuidEntity,
    ICreatedEntity
{
    public string Content { get; set; }

    public string Images { get; set; }

    public Guid ChatGroupId { get; set; }

    public Guid ReplyMessageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    // Navigation Properties
    public ChatGroupEntity ChatGroup { get; set; }

    public ChatMessageEntity ReplyMessage { get; set; }

    public UserEntity Sender { get; set; }

    #region MetaData
    public static class MetaData
    {
        public const string TableName = "ChatMessages";
    }
    #endregion
}