using DataAccess.Core.Entities;
using DataAccess.Specifications.Base.Generics;

namespace DataAccess.Specifications.Implementations.ChatGroups;

public class GetChatGroupByIdSpecification :
    GenericGetByIdSpecification<ChatGroupEntity>
{
    public GetChatGroupByIdSpecification(Guid id) : base(id)
    {
    }
}
