using DataAccess.Core.Entities;
using DataAccess.Specifications.Base.Generics;

namespace DataAccess.Specifications.Implementations.ChatMessages;

public class GetChatMessageByIdSpecification :
    GenericGetByIdSpecification<ChatGroupEntity>
{
    public GetChatMessageByIdSpecification(Guid id) : base(id)
    {
    }
}
