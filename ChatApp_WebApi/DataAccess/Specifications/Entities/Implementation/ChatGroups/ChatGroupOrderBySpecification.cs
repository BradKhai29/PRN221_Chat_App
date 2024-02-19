using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups
{
    public class ChatGroupOrderBySpecification :
        GenericSpecification<ChatGroupEntity>,
        IChatGroupOrderBySpecification
    {
        public IChatGroupOrderBySpecification ByCreatedAt(bool isAscending = true)
        {
            if (isAscending)
            {
                OrderByAscendingExpression = chatGroup => chatGroup.CreatedAt;
            }
            else
            {
                OrderByDescendingExpression = chatGroup => chatGroup.CreatedAt;
            }

            return this;
        }

        public IChatGroupOrderBySpecification ByCreatedBy(bool isAscending = true)
        {
            if (isAscending)
            {
                OrderByAscendingExpression = chatGroup => chatGroup.CreatedBy;
            }
            else
            {
                OrderByDescendingExpression = chatGroup => chatGroup.CreatedBy;
            }

            return this;
        }
    }
}
