using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base
{
    public interface IChatGroupMemberOrderBySpecification :
        IGenericSpecification<ChatGroupMemberEntity>
    {
        // By + Property : General
        IChatGroupMemberOrderBySpecification ByLastAccessedAt(bool isAscending);

        // By + Usecase Name:

        // For + Usecase Name.
    }
}
