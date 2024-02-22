using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base
{
    public interface IRefreshTokenWhereSpecification :
        IGenericSpecification<RefreshTokenEntity>
    {
        /// <summary>
        ///     This specification is used to verify
        ///     if the input refreshToken instance is valid or not.
        /// </summary>
        /// <remarks>
        ///     The implementation will check 3 properties: userId, tokenValue
        ///     and accessTokenId for the verification.
        /// </remarks>
        /// <param name="refreshToken">
        ///     The refreshToken that needed to be checked.
        /// </param>
        /// <returns></returns>
        IRefreshTokenWhereSpecification ForVerification(RefreshTokenEntity refreshToken);
    }
}
