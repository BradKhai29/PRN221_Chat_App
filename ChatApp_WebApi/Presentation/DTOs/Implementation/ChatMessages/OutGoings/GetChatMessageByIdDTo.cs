namespace Presentation.DTOs.Implementation.ChatMessages.OutGoings;

public class GetChatMessageByIdDto
{
    public Guid MessageId { get; set; }

    // Constructor for initializing with a messageId
    public GetChatMessageByIdDto(Guid messageId)
    {
        MessageId = messageId;
    }

    // Parameterless constructor if needed for serialization/deserialization
    public GetChatMessageByIdDto() { }
}
