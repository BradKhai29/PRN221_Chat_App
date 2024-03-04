using BusinessLogic.Services.Entities.Base;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class ChatGroupMemberHandlingService :
        IChatGroupMemberHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;

        public ChatGroupMemberHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager)
        {
            _specificationManager = specificationManager;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ChatGroupMemberEntity>> GetAllJoinedGroupsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _unitOfWork.ChatGroupMemberRepository.GetAllBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.ChatGroupMember.Where.ByMemberId(userId),
                _specificationManager.ChatGroupMember.Select.ForGetAllJoinedGroups(),
                _specificationManager.ChatGroupMember.AsNoTracking);
        }
    }
}
