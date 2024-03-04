using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.Users.Base;
using DataAccess.Specifications.Managers.Entities.Base.Generics;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IUserSpecificationManager :
        IGenericAsNoTrackingSpecificationManager<UserEntity>,
        IGenericAsSplitQuerySpecificationManager<UserEntity>
    {
        IUserWhereSpecification Where { get; }

        IUserSelectSpecification Select { get; }
    }
}
