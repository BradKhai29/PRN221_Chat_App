using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base
{
    public interface IChatGroupMemberRepository : 
        IGenericRepository<ChatGroupMemberEntity>
    {
    }
}
