using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IChatGroupMemberSpecificationManager :
        IGenericAsNoTrackingSpecificationManager<ChatGroupMemberEntity>,
        IGenericAsSplitQuerySpecificationManager<ChatGroupMemberEntity>
    {
        IChatGroupMemberWhereSpecification Where { get; }

        IChatGroupMemberSelectSpecification Select { get; }
    }
}
