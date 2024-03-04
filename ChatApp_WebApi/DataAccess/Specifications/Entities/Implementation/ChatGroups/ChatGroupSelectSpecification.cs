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
                CreatedAt = chatGroup.CreatedAt,
                Creator = new UserEntity
                {
                    Id = chatGroup.CreatedBy,
                    UserName = chatGroup.Creator.UserName,
                    AvatarUrl = chatGroup.Creator.AvatarUrl
                },
                MemberCount = chatGroup.MemberCount
            };

            return this;
        }

        public IChatGroupSelectSpecification ForListDisplay()
        {
            SelectExpression = chatGroup => new ChatGroupEntity
            {
                Id = chatGroup.Id,
                Name = chatGroup.Name,
                CreatedAt = chatGroup.CreatedAt,
            };

            return this;
        }
    }
}
