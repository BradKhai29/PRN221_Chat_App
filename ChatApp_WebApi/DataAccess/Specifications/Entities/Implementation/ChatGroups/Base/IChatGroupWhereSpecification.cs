using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups.Base
{
    public interface IChatGroupWhereSpecification : 
        IGenericSpecification<ChatGroupEntity>
    {
        IChatGroupWhereSpecification ById(Guid id);

        IChatGroupWhereSpecification ByName(string name);
    }
}
