using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Externals.Base;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class UserHandlingService : IUserHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;
        private readonly IPasswordHandlingService _passwordService;

        public UserHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager,
            IPasswordHandlingService passwordService)
        {
            _unitOfWork = unitOfWork;
            _specificationManager = specificationManager;
            _passwordService = passwordService;
        }

        public Task<UserEntity> FindUserByEmailAsync(
            string email,
            CancellationToken cancellationToken)
        {
            return _unitOfWork.UserRepository.FindBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.User.Where.ByEmail(email),
                _specificationManager.User.Select.ForEmailConfirmation(),
                _specificationManager.User.AsNoTracking);
        }

        public Task<bool> IsEmailConfirmedByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _unitOfWork.UserRepository.IsFoundBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.User.Where.IsEmailConfirmedStatus(userId));
        }

        public async Task<bool> UpdatePasswordAsync(
            Guid userId,
            string password,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    string passwordHash = _passwordService.GetHashPassword(password);

                    await _unitOfWork.UserRepository.BulkUpdatePasswordAsync(
                        userId: userId,
                        passwordHash: passwordHash,
                        cancellationToken: cancellationToken);

                    await _unitOfWork.CommitTransactionAsync(
                        cancellationToken: cancellationToken);

                    result = true;
                }
                catch
                {
                    await _unitOfWork.RollBackTransactionAsync(
                        cancellationToken: cancellationToken);
                }
                finally
                {
                    await _unitOfWork.DisposeTransactionAsync(
                        cancellationToken: cancellationToken);
                }
            });

            return result;
        }
    }
}
