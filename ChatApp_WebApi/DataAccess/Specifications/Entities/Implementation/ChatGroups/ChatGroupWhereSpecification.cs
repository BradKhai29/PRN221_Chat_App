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
            Criteria = chatGroup => chatGroup.Id.Equals(id);

            return this;
        }

        public IChatGroupWhereSpecification ByName(string name)
        {
            Criteria = chatGroup => chatGroup.Name.Equals(name);

            return this;
        }

        public IChatGroupWhereSpecification IsPublic()
        {
            Criteria = chatGroup => chatGroup.IsPrivate == false;

            return this;
        }
    }
}
