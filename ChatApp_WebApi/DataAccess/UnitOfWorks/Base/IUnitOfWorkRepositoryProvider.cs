using DataAccess.Repositories.Base;

namespace DataAccess.UnitOfWorks.Base
{
    /// <summary>
    ///     The base interface to implement UnitOfWork with repository.
    /// </summary>
    public interface IUnitOfWorkRepositoryProvider
    {
        IAccountStatusRepository AccountStatusRepository { get; }

        IUserRepository UserRepository { get; }

        IRoleRepository RoleRepository { get; }

        IUserRoleRepository UserRoleRepository { get; }

        IChatGroupTypeRepository ChatGroupTypeRepository { get; }

        IChatGroupRepository ChatGroupRepository { get; }

        IChatMessageRepository ChatMessageRepository { get; }

        IChatGroupMemberRepository ChatGroupMemberRepository { get; }

        IRefreshTokenRepository RefreshTokenRepository { get; }

        IUserTokenRepository UserTokenRepository { get; }
    }
}
