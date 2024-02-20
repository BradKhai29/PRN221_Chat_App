using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages.Base
{
    public interface IChatMessageWhereSpecification :
        IGenericSpecification<ChatMessageEntity>
    {
        IChatMessageWhereSpecification ByMessageId(Guid id);

        IChatMessageWhereSpecification ByChatGroupId(Guid id);

        /// <summary>
        ///     Filter the chat message by the input content.
        /// </summary>
        /// <param name="content">
        ///     The content of chat message to filter.
        /// </param>
        /// <returns></returns>
        IChatMessageWhereSpecification ForFilterByContent(string content);
    }
}
