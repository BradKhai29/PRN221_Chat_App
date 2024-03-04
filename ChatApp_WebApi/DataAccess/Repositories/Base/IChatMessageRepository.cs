using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base;

public interface IChatMessageRepository 
    : IGenericRepository<ChatMessageEntity>
{
    Task<int> BulkUpdateForContent(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken);

    Task<int> BulkUpdateForImages(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken);

    Task<int> BulkDeleteById(Guid id, CancellationToken cancellationToken);
}
