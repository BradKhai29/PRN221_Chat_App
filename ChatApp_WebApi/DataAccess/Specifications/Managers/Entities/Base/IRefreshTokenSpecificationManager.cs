using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IRefreshTokenSpecificationManager :
        IGenericAsNoTrackingSpecificationManager<RefreshTokenEntity>
    {
        IRefreshTokenWhereSpecification Where { get; }
    }
}
