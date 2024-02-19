using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base;

public interface IChatMessageRepository 
    : IGenericRepository<ChatMessageEntity>
{
    public Task<int> BulkUpdateForContent(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken);

    public Task<int> BulkUpdateForImages(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken);
}
