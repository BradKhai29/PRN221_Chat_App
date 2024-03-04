using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.UserTokens.Base;

namespace DataAccess.Specifications.Entities.Implementation.UserTokens
{
    internal class UserTokenSelectSpecification :
        GenericSpecification<UserTokenEntity>,
        IUserTokenSelectSpecification
    {
        public IUserTokenSelectSpecification ForResetPassword()
        {
            SelectExpression = resetPasswordToken => new UserTokenEntity
            {
                UserId = resetPasswordToken.UserId,
                Value = resetPasswordToken.Value
            };

            return this;
        }
    }
}
