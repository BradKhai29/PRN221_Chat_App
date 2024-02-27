using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IChatMessageHandlingService
    {
        Task<bool> CreateAsync(
            ChatMessageEntity chatMessage,
            CancellationToken cancellationToken);

        Task<bool> UpdateContentAsync(
            ChatMessageEntity chatMessage,
            CancellationToken cancellationToken);

        Task<bool> UpdateReplyMessageAsync(
            ChatMessageEntity replyMessage,
            CancellationToken cancellationToken);

        Task<bool> RemoveAsync(
            ChatMessageEntity chatMessage,
            CancellationToken cancellationToken);
    }
}
