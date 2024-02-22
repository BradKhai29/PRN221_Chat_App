using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers
{
    internal class ChatGroupMemberOrderBySpecification
        : GenericSpecification<ChatGroupMemberEntity>,
        IChatGroupMemberOrderBySpecification
    {
        public IChatGroupMemberOrderBySpecification ByLastAccessedAt(bool isAscending)
        {
            if (isAscending)
            {
                OrderByAscendingExpression = groupMember => groupMember.LastAccessedAt;
            }
            else
            {
                OrderByDescendingExpression = groupMember => groupMember.LastAccessedAt;
            }

            return this;
        }
    }
}
