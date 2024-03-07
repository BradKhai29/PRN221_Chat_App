using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DataAccess.Commons.SystemConstants;
using Presentation.DTOs.Base;

namespace Presentation.DTOs.Implementation.ChatMessages.InComings;

/// <summary>
/// Represents a DTO for creating a chat message.
/// </summary>
public class CreateChatMessageDto :
    IDtoNormalization
{
    public Guid ChatGroupId { get; set; }

    public Guid ReplyMessageId { get; set; }

    public string Content { get; set; }

    public IFormFile Images { get; set; }

    public DateTime CreatedAt { get; set; }

    public void NormalizeAllProperties()
    {
        Content = Content?.Trim();

        if (Equals(CreatedAt, default))
        {
            CreatedAt = DateTime.UtcNow;
        }

        if (Equals(ReplyMessageId, default))
        {
            ReplyMessageId = DefaultValues.SystemId;
        }
    }
}
