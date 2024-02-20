using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.UserRoles.Base;

namespace DataAccess.Specifications.Entities.Implementation.UserRoles
{
    public class UserRoleWhereSpecification :
        GenericSpecification<UserRoleEntity>,
        IUserRoleWhereSpecification
    {
        public IUserRoleWhereSpecification IsUserHasRole(Guid userId, Guid roleId)
        {
            Criteria = userRole => 
                userRole.UserId.Equals(userId)
                && userRole.RoleId.Equals(roleId);

            return this;
        }
    }
}
