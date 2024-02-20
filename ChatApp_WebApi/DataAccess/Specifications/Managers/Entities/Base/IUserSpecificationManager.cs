using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.Users.Base;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IUserSpecificationManager
    {
        IUserWhereSpecification Where { get; }

        IUserSelectSpecification Select { get; }

        GenericAsNoTrackingSpecification<UserEntity> AsNoTracking { get; }

        GenericAsSplitQuerySpecification<UserEntity> AsSplitQuery { get; }
    }
}
