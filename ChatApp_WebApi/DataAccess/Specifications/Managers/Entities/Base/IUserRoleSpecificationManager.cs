using DataAccess.Specifications.Entities.Implementation.UserRoles.Base;

namespace DataAccess.Specifications.Managers.Entities.Base
{
    public interface IUserRoleSpecificationManager
    {
        IUserRoleWhereSpecification Where { get; }
    }
}
