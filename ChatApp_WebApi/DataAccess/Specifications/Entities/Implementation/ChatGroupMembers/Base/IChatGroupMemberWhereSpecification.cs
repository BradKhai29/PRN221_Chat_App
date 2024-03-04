using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base
{
    public interface IChatGroupMemberWhereSpecification :
        IGenericSpecification<ChatGroupMemberEntity>
    {
        IChatGroupMemberWhereSpecification ByChatGroupId(Guid id);

        IChatGroupMemberWhereSpecification IsMemberInGroup(Guid memberId, Guid chatGroupId);

        IChatGroupMemberWhereSpecification IsMemberHasPermission(
            Guid memberId,
            Guid chatGroupId,
            Guid roleId);

        IChatGroupMemberWhereSpecification ByMemberId(Guid memberId);
    }
}
