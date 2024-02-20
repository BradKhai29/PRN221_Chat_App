using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatGroups.Base;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IChatGroupSpecificationManager
    {
        IChatGroupWhereSpecification Where { get; }

        IChatGroupSelectSpecification Select { get; }

        IChatGroupOrderBySpecification OrderBy { get; }

        GenericPaginationSpecification<ChatGroupEntity> Pagination(int skipNumber, int takeNumber);

        GenericAsNoTrackingSpecification<ChatGroupEntity> AsNoTracking { get; }

        GenericAsSplitQuerySpecification<ChatGroupEntity> AsSplitQuery { get; }
    }
}
