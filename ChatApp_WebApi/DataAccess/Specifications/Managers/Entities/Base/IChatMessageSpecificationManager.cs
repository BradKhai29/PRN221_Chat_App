using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Implementation.ChatMessages.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base;

public interface IChatMessageSpecificationManager :
    IGenericAsNoTrackingSpecificationManager<ChatMessageEntity>,
    IGenericAsSplitQuerySpecificationManager<ChatMessageEntity>,
    IGenericPaginationSpecificationManager<ChatMessageEntity>
{
    IChatMessageWhereSpecification Where { get; }

    IChatMessageSelectSpecification Select { get; }

    IChatMessageOrderBySpecification OrderBy { get; }
}
