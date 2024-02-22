using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages.Base
{
    public interface IChatMessageOrderBySpecification :
        IGenericSpecification<ChatMessageEntity>
    {
        /// <summary>
        ///     Order the list by the datetime when the 
        ///     chat-message was created descendingly.
        /// </summary>
        IChatMessageOrderBySpecification ByCreatedAtDescendingly();
    }
}
