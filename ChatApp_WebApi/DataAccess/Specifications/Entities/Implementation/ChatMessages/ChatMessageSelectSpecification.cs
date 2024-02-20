using DataAccess.Commons.SystemConstants;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatMessages
{
    internal class ChatMessageSelectSpecification :
        GenericSpecification<ChatMessageEntity>,
        IChatMessageSelectSpecification
    {
        public IChatMessageSelectSpecification ForListDisplay()
        {
            SelectExpression = message => new ChatMessageEntity
            {
                Id = message.Id,
                Content = message.Content,
                Images = message.Images,
                CreatedAt = message.CreatedAt,
                CreatedBy = message.CreatedBy,
                ReplyMessageId = message.ReplyMessageId.Equals(DefaultValues.SystemId) 
                    ? Guid.Empty
                    : message.ReplyMessageId,
                ReplyMessage = new ChatMessageEntity
                {
                    Id = message.ReplyMessageId,
                    Content = message.ReplyMessageId.Equals(DefaultValues.SystemId) 
                        ? null 
                        : message.ReplyMessage.Content,
                },
                UpdatedAt = message.UpdatedAt
            };

            return this;
        }
    }
}
