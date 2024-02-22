using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    /// <summary>
    ///     This interface provides method to work 
    ///     with refresh-token entity.
    /// </summary>
    public interface IRefreshTokenHandlingService
    {
        /// <summary>
        ///     Generate a refresh-token entity by input <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">
        ///     The userId this refresh-token belonged to.
        /// </param>
        /// <param name="lifeSpan">
        ///     The time-span this refresh-token lives and is valid
        ///     to use for re-create a new refresh-token.
        /// </param>
        /// <returns>
        ///     A new refresh-token instance.
        /// </returns>
        RefreshTokenEntity Generate(Guid userId, TimeSpan lifeSpan);

        /// <summary>
        ///     Add the refresh-token instance into database.
        /// </summary>
        /// <param name="refreshToken">
        ///     The refresh-token instance that needed to be added.
        /// </param>
        /// <returns>
        ///     The (bool) result of adding the input instance into database.
        /// </returns>
        Task<bool> AddAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken);

        Task<bool> RemoveAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Check if the input refresh-token is valid or not.
        /// </summary>
        /// <remarks>
        ///     This method will check under the database.
        /// </remarks>
        /// <param name="refreshToken"></param>
        /// <returns>
        ///     The (bool) result of checking the input instance from database.
        /// </returns>
        Task<bool> IsValidAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken);
    }
}
