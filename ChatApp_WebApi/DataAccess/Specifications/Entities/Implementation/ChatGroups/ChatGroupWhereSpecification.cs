using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;

namespace DataAccess.Specifications.Entities.Implementation.ChatGroups
{
    public class ChatGroupWhereSpecification :
        GenericSpecification<ChatGroupEntity>,
        IChatGroupWhereSpecification
    {
        public IChatGroupWhereSpecification ById(Guid id)
        {
            Criteria = entity => entity.Id.Equals(id);

            return this;
        }

        public IChatGroupWhereSpecification ByName(string name)
        {
            Criteria = entity => entity.Name.Equals(name);

            return this;
        }
    }
}
