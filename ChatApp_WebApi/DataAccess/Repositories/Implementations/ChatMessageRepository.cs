using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Implementations;

public class ChatMessageRepository :
    GenericRepository<ChatMessageEntity>,
    IChatMessageRepository
{
    public ChatMessageRepository(ChatAppDbContext dbContext) : base(dbContext)
    {
    }

    public Task<int> BulkUpdateForChatMessageContent(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
