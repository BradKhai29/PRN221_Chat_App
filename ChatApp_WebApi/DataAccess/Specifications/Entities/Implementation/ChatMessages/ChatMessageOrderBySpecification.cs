using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages
{
    internal class ChatMessageOrderBySpecification :
        GenericSpecification<ChatMessageEntity>,
        IChatMessageOrderBySpecification
    {
        public IChatMessageOrderBySpecification ByCreatedAtDescendingly()
        {
            OrderByDescendingExpression = message => message.CreatedAt;

            return this;
        }
    }
}
