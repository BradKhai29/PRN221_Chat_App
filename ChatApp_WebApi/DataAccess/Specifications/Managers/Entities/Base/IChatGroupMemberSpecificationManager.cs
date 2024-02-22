using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroupMembers.Base;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IChatGroupMemberSpecificationManager
    {
        IChatGroupMemberWhereSpecification Where { get; }

        GenericAsNoTrackingSpecification<ChatGroupMemberEntity> AsNoTracking { get; }

        GenericAsSplitQuerySpecification<ChatGroupMemberEntity> AsSplitQuery { get; }
    }
}
