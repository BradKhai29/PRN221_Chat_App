using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IRefreshTokenSpecificationManager
    {
        IRefreshTokenWhereSpecification Where { get; }

        GenericAsNoTrackingSpecification<RefreshTokenEntity> AsNoTracking { get; }
    }
}
