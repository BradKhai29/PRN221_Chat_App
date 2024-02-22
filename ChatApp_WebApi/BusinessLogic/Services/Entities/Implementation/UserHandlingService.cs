using BusinessLogic.Services.Entities.Base;
using DataAccess.Core;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class UserHandlingService : IUserHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;

        public UserHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager)
        {
            _unitOfWork = unitOfWork;
            _specificationManager = specificationManager;
        }


        public Task<bool> IsEmailExistedAsync(string email, CancellationToken cancellationToken)
        {
            return _unitOfWork.UserRepository.IsFoundBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.User.Where.ByEmail(email));
        }

        public Task<bool> IsUsernameExistedAsync(string username, CancellationToken cancellationToken)
        {
            return _unitOfWork.UserRepository.IsFoundBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.User.Where.ByUsername(username));
        }
    }
}
