using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers
{
    public class ChatGroupMemberWhereSpecification :
        GenericSpecification<ChatGroupMemberEntity>,
        IChatGroupMemberWhereSpecification
    {
        public IChatGroupMemberWhereSpecification ByChatGroupId(Guid id)
        {
            Criteria = chatGroupMember => chatGroupMember.ChatGroupId.Equals(id);

            return this;
        }

        public IChatGroupMemberWhereSpecification ByMemberId(Guid memberId)
        {
            Criteria = chatGroupMember => chatGroupMember.MemberId.Equals(memberId);

            return this;
        }

        public IChatGroupMemberWhereSpecification IsMemberHasPermission(
            Guid memberId,
            Guid chatGroupId,
            Guid roleId)
        {
            Criteria = chatGroupMember => 
                chatGroupMember.MemberId.Equals(memberId)
                && chatGroupMember.ChatGroupId.Equals(chatGroupId)
                && chatGroupMember.RoleId.Equals(roleId);

            return this;
        }

        public IChatGroupMemberWhereSpecification IsMemberInGroup(Guid memberId, Guid chatGroupId)
        {
            Criteria = chatGroupMember => 
                chatGroupMember.MemberId.Equals(memberId)
                && chatGroupMember.ChatGroupId.Equals(chatGroupId);

            return this;
        }
    }
}
