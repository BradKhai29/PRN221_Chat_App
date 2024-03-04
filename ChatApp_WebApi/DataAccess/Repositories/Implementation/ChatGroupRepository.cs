using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class ChatGroupRepository :
    GenericRepository<ChatGroupEntity>,
    IChatGroupRepository
{
    public ChatGroupRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public Task<int> BulkDeleteByIdAsync(
        Guid chatGroupId,
        CancellationToken cancellationToken)
    {
        return _dbSet
            .Where(chatGroup => chatGroup.Id.Equals(chatGroupId))
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}
