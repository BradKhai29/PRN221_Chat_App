using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;

namespace DataAccess.Specifications.Managers.Entities.Base;

public interface IChatMessageSpecificationManager
{
    IChatMessageWhereSpecification Where { get; }

    IChatMessageSelectSpecification Select { get; }

    IChatMessageOrderBySpecification OrderBy { get; }

    GenericPaginationSpecification<ChatMessageEntity> Pagination(int skipNumber, int takeNumber);

    GenericAsNoTrackingSpecification<ChatMessageEntity> AsNoTracking { get; }

    GenericAsSplitQuerySpecification<ChatMessageEntity> AsSplitQuery { get; }
}
