using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups
{
    public class ChatGroupSelectSpecification :
        GenericSpecification<ChatGroupEntity>,
        IChatGroupSelectSpecification
    {
        public IChatGroupSelectSpecification ForDetailDisplay()
        {
            SelectExpression = chatGroup => new ChatGroupEntity
            {
                Id = chatGroup.Id,
                Name = chatGroup.Name,
                IsPrivate = chatGroup.IsPrivate,
                ChatGroupTypeId = chatGroup.ChatGroupTypeId,
                CreatedAt = chatGroup.CreatedAt,
                CreatedBy = chatGroup.CreatedBy,
                MemberCount = chatGroup.MemberCount,
                Creator = new UserEntity
                {
                    Id = chatGroup.CreatedBy,
                    UserName = chatGroup.Creator.UserName
                },
                ChatGroupMembers = chatGroup.ChatGroupMembers
                    .Select(groupMember => new ChatGroupMemberEntity
                    {
                        MemberId = groupMember.MemberId,
                        ChatGroupId = groupMember.ChatGroupId,
                        Member = new UserEntity
                        {
                            Id = groupMember.MemberId,
                            UserName = groupMember.Member.UserName
                        }
                    })
            };

            return this;
        }

        public IChatGroupSelectSpecification ForListDisplay()
        {
            SelectExpression = chatGroup => new ChatGroupEntity
            {
                Id = chatGroup.Id,
                Name = chatGroup.Name,
                CreatedAt = chatGroup.CreatedAt
            };

            return this;
        }
    }
}
