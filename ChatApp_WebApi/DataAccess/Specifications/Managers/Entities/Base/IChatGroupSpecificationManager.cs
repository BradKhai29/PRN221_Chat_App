using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IChatGroupSpecificationManager :
        IGenericAsNoTrackingSpecificationManager<ChatGroupEntity>,
        IGenericAsSplitQuerySpecificationManager<ChatGroupEntity>,
        IGenericPaginationSpecificationManager<ChatGroupEntity>
    {
        IChatGroupWhereSpecification Where { get; }

        IChatGroupSelectSpecification Select { get; }

        IChatGroupOrderBySpecification OrderBy { get; }
    }
}
