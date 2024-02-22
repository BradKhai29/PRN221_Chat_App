using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base
{
    public interface IChatGroupMemberOrderBySpecification :
        IGenericSpecification<ChatGroupMemberEntity>
    {
        IChatGroupMemberOrderBySpecification ByLastAccessedAt(bool isAscending);
    }
}
