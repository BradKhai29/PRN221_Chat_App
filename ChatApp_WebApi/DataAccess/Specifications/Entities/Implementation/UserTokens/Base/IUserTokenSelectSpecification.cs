using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.UserTokens.Base
{
    public interface IUserTokenSelectSpecification :
        IGenericSpecification<UserTokenEntity>
    {
        IUserTokenSelectSpecification ForResetPassword();
    }
}
