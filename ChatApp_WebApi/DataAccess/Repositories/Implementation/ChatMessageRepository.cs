using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class ChatMessageRepository :
    GenericRepository<ChatMessageEntity>,
    IChatMessageRepository
{
    public ChatMessageRepository(DbContext dbContext) : base(dbContext)
    {
    }
    public Task<int> BulkDeleteById(Guid id, CancellationToken cancellationToken)
    {
        return _dbSet
            .Where(message => message.Id.Equals(id))
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public Task<int> BulkUpdateForContent(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> BulkUpdateForImages(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
