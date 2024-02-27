using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroupMembers
{
    internal class ChatGroupMemberSelectSpecification :
        GenericSpecification<ChatGroupMemberEntity>,
        IChatGroupMemberSelectSpecification
    {
        public IChatGroupMemberSelectSpecification ForGetAllJoinedGroups()
        {
            SelectExpression = chatGroupMember => new ChatGroupMemberEntity
            {
                Member = new UserEntity
                {
                    Id = chatGroupMember.MemberId,
                    UserName = chatGroupMember.Member.UserName,
                },
                ChatGroup = new ChatGroupEntity
                {
                    Id = chatGroupMember.ChatGroupId,
                    Name = chatGroupMember.ChatGroup.Name,
                },
                LastAccessedAt = chatGroupMember.LastAccessedAt
            };

            return this;
        }

        public IChatGroupMemberSelectSpecification ForListDisplay()
        {
            SelectExpression = chatGroupMember => new ChatGroupMemberEntity
            {
                Member = new UserEntity
                {
                    Id = chatGroupMember.MemberId,
                    UserName = chatGroupMember.Member.UserName,
                },
                Role = new RoleEntity
                {
                    Name = chatGroupMember.Role.Name
                }
            };

            return this;
        }
    }
}
