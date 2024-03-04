using BusinessLogic.Models.Base;
using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IChatGroupHandlingService
    {
        /// <summary>
        ///     Create a new chat group with specified list of members.
        /// </summary>
        /// <param name="chatGroup">
        ///     The chat group entity to create.
        /// </param>
        /// <param name="chatGroupMembers">
        ///     The list of first members this group have.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns>
        ///     The result (bool) of creating the chat-group.
        /// </returns>
        Task<bool> CreateAsync(
            ChatGroupEntity chatGroup,
            IEnumerable<ChatGroupMemberEntity> chatGroupMembers,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Create a chat group with personal usage for specified user.
        /// </summary>
        /// <param name="user">
        ///     The user that need to create only-me chat group.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IResult<ChatGroupMemberEntity>> CreateOnlyMeChatGroupByUserIdAsync(
            UserEntity user,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Permanently remove the chat group with specified Id.
        /// </summary>
        /// <remarks>
        ///     <b>Warning</b>: This operation cannot reverse, please aware to use it carefully.
        /// </remarks>
        /// <param name="chatGroupId">
        ///     The Id of the chat group.
        /// </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> PermanentlyRemoveAsync(Guid chatGroupId, CancellationToken cancellationToken);

        Task<bool> IsFoundByIdAsync(Guid chatGroupId, CancellationToken cancellationToken);

        /// <summary>
        ///     Get all chat groups that are public to join.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<ChatGroupEntity>> GetAllPublicChatGroupsAsync(
            CancellationToken cancellationToken);
        /// <summary>
        ///     Get all group chat with specified Id.
        /// </summary>
        /// <param name="chatGroupId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<ChatGroupEntity> FindByIdAsync(
            Guid chatGroupId,
            CancellationToken cancellationToken);
    }
}
