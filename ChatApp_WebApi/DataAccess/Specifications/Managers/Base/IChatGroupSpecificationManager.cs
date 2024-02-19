using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;

namespace DataAccess.Specifications.Managers.Base
{
    public interface IChatGroupSpecificationManager
    {
        IChatGroupWhereSpecification WhereSpecification { get; }

        IChatGroupSelectSpecification SelectSpecification { get; }

        IChatGroupOrderBySpecification OrderBySpecification { get; }

        GenericPaginationSpecification<ChatGroupEntity> PaginationSpecification { get; }

        GenericAsNoTrackingSpecification<ChatGroupEntity> AsNoTrackingSpecification { get; }

        GenericAsSplitQuerySpecification<ChatGroupEntity> AsSplitQuerySpecification { get; }
    }
}
