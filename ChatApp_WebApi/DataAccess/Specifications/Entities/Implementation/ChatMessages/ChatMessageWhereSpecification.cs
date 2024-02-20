using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages;

public class ChatMessageWhereSpecification :
    GenericSpecification<ChatMessageEntity>,
    IChatMessageWhereSpecification
{
    public IChatMessageWhereSpecification ByChatGroupId(Guid id)
    {
        Criteria = chatMessage => chatMessage.ChatGroupId.Equals(id);

        return this;
    }

    public IChatMessageWhereSpecification ByMessageId(Guid id)
    {
        Criteria = chatMessage => chatMessage.Id.Equals(id);

        return this;
    }

    public IChatMessageWhereSpecification ForFilterByContent(string content)
    {
        Criteria = chatMessage => EF.Functions
            .Collate(chatMessage.Content, SqlCollations.SqlServer.LATIN1_GENERAL_CI_AI)
            .Equals(content);

        return this;
    }
}
