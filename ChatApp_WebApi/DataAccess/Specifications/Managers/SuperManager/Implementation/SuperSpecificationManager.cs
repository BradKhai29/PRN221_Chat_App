using DataAccess.Specifications.Managers.Entities.Base;
using DataAccess.Specifications.Managers.Entities.Implementation;
using DataAccess.Specifications.Managers.SuperManager.Base;

namespace DataAccess.Specifications.Managers.SuperManager.Implementation
{
    internal sealed class SuperSpecificationManager :
        ISuperSpecificationManager
    {
        // Backing fields.
        private IChatGroupMemberSpecificationManager _chatGroupMemberSpecificationManager;
        private IChatGroupSpecificationManager _chatGroupSpecificationManager;
        private IChatMessageSpecificationManager _chatMessageSpecificationManager;
        private IRefreshTokenSpecificationManager _refreshTokenSpecificationManager;
        private IUserSpecificationManager _userSpecificationManager;
        private IUserRoleSpecificationManager _userRoleSpecificationManager;
        private IUserTokenSpecificationManager _userTokenSpecificationManager;

        public IChatGroupSpecificationManager ChatGroup
        {
            get
            {
                _chatGroupSpecificationManager ??= new ChatGroupSpecificationManager();

                return _chatGroupSpecificationManager;
            }
        }

        public IChatGroupMemberSpecificationManager ChatGroupMember
        {
            get
            {
                _chatGroupMemberSpecificationManager ??= new ChatGroupMemberSpecificationManager();

                return _chatGroupMemberSpecificationManager;
            }
        }

        public IChatMessageSpecificationManager ChatMessage
        {
            get
            {
                _chatMessageSpecificationManager ??= new ChatMessageSpecificationManager();

                return _chatMessageSpecificationManager;
            }
        }

        public IRefreshTokenSpecificationManager RefreshToken
        {
            get
            {
                _refreshTokenSpecificationManager ??= new RefreshTokenSpecificationManager();

                return _refreshTokenSpecificationManager;
            }
        }

        public IUserSpecificationManager User
        {
            get
            {
                _userSpecificationManager ??= new UserSpecificationManager();

                return _userSpecificationManager;
            }
        }

        public IUserRoleSpecificationManager UserRole
        {
            get
            {
                _userRoleSpecificationManager ??= new UserRoleSpecificationManager();

                return _userRoleSpecificationManager;
            }
        }

        public IUserTokenSpecificationManager UserToken
        {
            get
            {
                _userTokenSpecificationManager ??= new UserTokenSpecificationManager();

                return _userTokenSpecificationManager;
            }
        }
    }
}
