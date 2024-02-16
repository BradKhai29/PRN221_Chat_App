using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base;

public interface IChatMessageRepository : IGenericRepository<ChatMessageEntity>
{
    public Task<int> BulkUpdateForChatMessageContent(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken);
}
