using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages.Base
{
    public interface IChatMessageOrderBySpecification :
        IGenericSpecification<ChatMessageEntity>
    {
        /// <summary>
        ///     Order the list by the datetime when this chat-message was created.
        /// </summary>
        /// <param name="isAscending">
        ///     Default is true
        /// </param>
        /// <returns></returns>
        IChatMessageOrderBySpecification ByCreatedAt(bool isAscending);
    }
}
