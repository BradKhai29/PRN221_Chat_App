using BusinessLogic.Services.Entities.Base;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class RefreshTokenHandlingService :
        IRefreshTokenHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;

        public RefreshTokenHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager)
        {
            _unitOfWork = unitOfWork;
            _specificationManager = specificationManager;
        }

        public async Task<bool> AddAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    await _unitOfWork.RefreshTokenRepository.AddAsync(
                        newEntity: refreshToken,
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

        public RefreshTokenEntity Generate(Guid userId, TimeSpan lifeSpan)
        {
            return new RefreshTokenEntity
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Value = StringHelper.GetRandomValue(32),
                AccessTokenId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.Add(lifeSpan),
            };
        }

        public Task<bool> IsValidAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken)
        {
            return _unitOfWork.RefreshTokenRepository.IsFoundBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.RefreshToken.Where.ForVerification(refreshToken: refreshToken));
        }

        public async Task<bool> RemoveAsync(
            RefreshTokenEntity refreshToken,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    _unitOfWork.RefreshTokenRepository.Remove(foundEntity: refreshToken);

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
    }
}
