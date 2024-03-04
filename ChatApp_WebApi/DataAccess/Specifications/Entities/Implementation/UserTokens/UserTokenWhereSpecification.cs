using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.UserTokens.Base;

namespace DataAccess.Specifications.Entities.Implementation.UserTokens
{
    internal class UserTokenWhereSpecification :
        GenericSpecification<UserTokenEntity>,
        IUserTokenWhereSpecification
    {
        public IUserTokenWhereSpecification ByUserIdAndTokenName(Guid userId, string tokenName)
        {
            Criteria = userToken => 
                userToken.UserId.Equals(userId)
                && userToken.Name.Equals(tokenName);

            return this;
        }

        public IUserTokenWhereSpecification ForResetPasswordValidation(Guid userId, string tokenValue)
        {
            var dateTimeNow = DateTime.UtcNow;

            Criteria = userToken => 
                userToken.UserId.Equals(userId)
                && userToken.Value.Equals(tokenValue)
                && userToken.ExpiredAt > dateTimeNow;

            return this;
        }
    }
}
