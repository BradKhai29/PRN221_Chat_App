using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.UserRoles.Base
{
    public interface IUserRoleWhereSpecification :
        IGenericSpecification<UserRoleEntity>
    {
        IUserRoleWhereSpecification IsUserHasRole(Guid userId, Guid roleId);
    }
}
