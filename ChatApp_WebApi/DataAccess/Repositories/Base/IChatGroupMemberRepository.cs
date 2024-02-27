using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base
{
    public interface IChatGroupMemberRepository : 
        IGenericRepository<ChatGroupMemberEntity>
    {
        Task<int> BulkDeleteByChatGroupIdAsync(
            Guid chatGroupId,
            CancellationToken cancellationToken);
    }
}
