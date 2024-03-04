using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IChatGroupMemberHandlingService
    {
        /// <summary>
        ///     Get the list of groups the user with specified Id has joined.
        /// </summary>
        /// <param name="userId">
        ///     The userId to find.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ChatGroupMemberEntity>> GetAllJoinedGroupsByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken);
    }
}
