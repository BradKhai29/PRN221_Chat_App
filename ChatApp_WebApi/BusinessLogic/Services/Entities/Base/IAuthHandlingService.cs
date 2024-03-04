using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IAuthHandlingService
    {
        Task<IResult<UserEntity>> LoginAsync(
            string username,
            string password,
            CancellationToken cancellationToken);

        Task<bool> IsUsernameExistedAsync(string username, CancellationToken cancellationToken);

        Task<bool> IsEmailExistedAsync(string email, CancellationToken cancellationToken);

        /// <summary>
        ///     Process to register a new user account with provided register info.
        /// </summary>
        /// <param name="registerInfo">
        ///     The register information that used to create a new user account.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     The <see cref="IResult{Guid}"/> that contains UserId of the registered account.
        /// </returns>
        Task<IResult<Guid>> RegisterAsync(
            RegisterInfoModel registerInfo,
            CancellationToken cancellationToken);

        Task<bool> ConfirmEmailForUserAsync(UserEntity user, CancellationToken cancellationToken);
    }
}
