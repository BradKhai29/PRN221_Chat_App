using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.Users.Base
{
    public interface IUserSelectSpecification : 
        IGenericSpecification<UserEntity>
    {
        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need to display detail information
        ///     of this user.
        /// </summary>
        IUserSelectSpecification ForDetailDisplay();

        /// <summary>
        ///     This specification is used to select required 
        ///     properties/fields that need for login feature.
        /// </summary>
        IUserSelectSpecification ForLogin();
    }
}
