using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using BusinessLogic.Services.Entities.Base;
using BusinessLogic.Services.Externals.Base;
using DataAccess.Commons.DataSeedings;
using DataAccess.Commons.SystemConstants;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class AuthHandlingService : IAuthHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;
        private readonly IPasswordHandlingService _passwordService;

        public AuthHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager,
            IPasswordHandlingService passwordService)
        {
            _unitOfWork = unitOfWork;
            _specificationManager = specificationManager;
            _passwordService = passwordService;
        }

        public async Task<bool> ConfirmEmailForUserAsync(
            UserEntity user,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    await _unitOfWork.UserRepository.BulkUpdateForEmailConfirmationAsync(
                        foundUser: user,
                        cancellationToken: cancellationToken);

                    await _unitOfWork.SaveChangesToDatabaseAsync(
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

        public async Task<IResult<UserEntity>> LoginAsync(
            string username,
            string password,
            CancellationToken cancellationToken)
        {
            var result = Result<UserEntity>.Failed();
            var passwordHash = _passwordService.GetHashPassword(password);

            var foundUser = await _unitOfWork.UserRepository.FindBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.User.Where.ForLogin(username, passwordHash),
                _specificationManager.User.Select.ForLogin());

            if (Equals(foundUser, null))
            {
                return result;
            }

            return Result<UserEntity>.Success(foundUser);
        }

        public async Task<IResult<Guid>> RegisterAsync(
            RegisterInfoModel registerInfo,
            CancellationToken cancellationToken)
        {
            var result = Result<Guid>.Failed();

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    var user = new UserEntity
                    {
                        Id = Guid.NewGuid(),
                        UserName = registerInfo.Username,
                        Email = registerInfo.Email,
                        PasswordHash = _passwordService.GetHashPassword(registerInfo.Password),
                        AccountStatusId = SeedingValues.AccountStatuses.EmailConfirmed.Id,
                        AvatarUrl = DefaultValues.UserAvatarUrl,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        RemovedAt = DefaultValues.MinDateTime,
                        PhoneNumber = string.Empty
                    };

                    await _unitOfWork.UserRepository.AddAsync(newEntity: user);

                    await _unitOfWork.SaveChangesToDatabaseAsync(
                        cancellationToken: cancellationToken);

                    await _unitOfWork.CommitTransactionAsync(
                        cancellationToken: cancellationToken);

                    result = Result<Guid>.Success(user.Id);
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
