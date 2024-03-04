using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.UserTokens.Base
{
    public interface IUserTokenWhereSpecification :
        IGenericSpecification<UserTokenEntity>
    {
        IUserTokenWhereSpecification ForResetPasswordValidation(Guid userId, string tokenValue);

        IUserTokenWhereSpecification ByUserIdAndTokenName(Guid userId, string tokenName);
    }
}
