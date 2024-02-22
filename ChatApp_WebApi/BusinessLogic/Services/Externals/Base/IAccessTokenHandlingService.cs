using System.Security.Claims;

namespace BusinessLogic.Services.Externals.Base
{
    /// <summary>
    ///     This interface provides methods to generate an access-token.
    /// </summary>
    public interface IAccessTokenHandlingService
    {
        /// <summary>
        ///     Generate an access-token that uses JwtToken
        ///     format from the received credentials.
        /// </summary>
        /// <param name="claims">
        ///     The claims this access token will encapsulate.
        /// </param>
        /// <param name="liveSpan">
        ///     The live span of this access-token.
        /// </param>
        /// 
        /// <returns>
        ///     A string that represents the access-token.
        /// </returns>
        string GenerateJwtToken(
            IEnumerable<Claim> claims,
            TimeSpan liveSpan);
    }
}
