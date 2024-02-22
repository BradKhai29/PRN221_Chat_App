using DataAccess.Specifications.Entities.Implementation.UserRoles;
using DataAccess.Specifications.Entities.Implementation.UserRoles.Base;
using DataAccess.Specifications.Managers.Entities.Base;

namespace DataAccess.Specifications.Managers.Entities.Implementation
{
    internal class UserRoleSpecificationManager :
        IUserRoleSpecificationManager
    {
        // Backing fields.
        private IUserRoleWhereSpecification _whereSpecification;

        public IUserRoleWhereSpecification Where
        {
            get
            {
                _whereSpecification ??= new UserRoleWhereSpecification();

                return _whereSpecification;
            }
        }
    }
}
