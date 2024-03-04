using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base
{
    public interface IChatGroupRepository 
        : IGenericRepository<ChatGroupEntity>
    {
        Task<int> BulkDeleteByIdAsync(Guid chatGroupId, CancellationToken cancellationToken);
    }
}
