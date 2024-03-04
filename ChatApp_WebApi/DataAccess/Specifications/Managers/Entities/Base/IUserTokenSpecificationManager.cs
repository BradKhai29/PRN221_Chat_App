using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Implementation.UserTokens.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IUserTokenSpecificationManager :
        IGenericAsNoTrackingSpecificationManager<UserTokenEntity>,
        IGenericAsSplitQuerySpecificationManager<UserTokenEntity>
    {
        IUserTokenWhereSpecification Where { get; }

        IUserTokenSelectSpecification Select { get; }
    }
}
