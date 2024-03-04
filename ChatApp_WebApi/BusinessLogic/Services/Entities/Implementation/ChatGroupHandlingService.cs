using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using BusinessLogic.Services.Entities.Base;
using DataAccess.Commons.DataSeedings;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Entities.Implementation
{
    internal class ChatGroupHandlingService :
        IChatGroupHandlingService
    {
        // Backing fields.
        private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
        private readonly ISuperSpecificationManager _specificationManager;

        public ChatGroupHandlingService(
            IUnitOfWork<ChatAppDbContext> unitOfWork,
            ISuperSpecificationManager specificationManager)
        {
            _specificationManager = specificationManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(
            ChatGroupEntity chatGroup,
            IEnumerable<ChatGroupMemberEntity> chatGroupMembers,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    await _unitOfWork.ChatGroupRepository.AddAsync(
                        newEntity: chatGroup,
                        cancellationToken: cancellationToken);

                    await _unitOfWork.ChatGroupMemberRepository.AddRangeAsync(
                        newEntities: chatGroupMembers,
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

        public async Task<IResult<ChatGroupMemberEntity>> CreateOnlyMeChatGroupByUserIdAsync(
            UserEntity user,
            CancellationToken cancellationToken)
        {
            var result = Result<ChatGroupMemberEntity>.Failed();

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    // Chat group details.
                    var newOnlyMeChatGroup = new ChatGroupEntity
                    {
                        Id = Guid.NewGuid(),
                        IsPrivate = true,
                        ChatGroupTypeId = SeedingValues.ChatGroupTypes.OnlyMe.Id,
                        Name = user.UserName,
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = user.Id,
                        MemberCount = 1,
                    };

                    await _unitOfWork.ChatGroupRepository.AddAsync(
                        newEntity: newOnlyMeChatGroup,
                        cancellationToken: cancellationToken);

                    // Member for only me chat group.
                    var member = new ChatGroupMemberEntity
                    {
                        ChatGroupId = newOnlyMeChatGroup.Id,
                        MemberId = user.Id,
                        CreatedAt = DateTime.UtcNow,
                        LastAccessedAt = DateTime.UtcNow,
                        RoleId = SeedingValues.Roles.ChatGroupMember.Id,
                    };

                    var chatGroupMembers = new List<ChatGroupMemberEntity>
                    {
                        member
                    };

                    await _unitOfWork.ChatGroupMemberRepository.AddRangeAsync(
                        newEntities: chatGroupMembers,
                        cancellationToken: cancellationToken);

                    await _unitOfWork.SaveChangesToDatabaseAsync(
                        cancellationToken: cancellationToken);

                    await _unitOfWork.CommitTransactionAsync(
                        cancellationToken: cancellationToken);

                    result = Result<ChatGroupMemberEntity>.Success(member);
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

        public Task<ChatGroupEntity> FindByIdAsync(
            Guid chatGroupId,
            CancellationToken cancellationToken)
        {
            return _unitOfWork.ChatGroupRepository.FindBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.ChatGroup.Where.ById(chatGroupId),
                _specificationManager.ChatGroup.Select.ForDetailDisplay(),
                _specificationManager.ChatGroup.AsNoTracking
            );
        }

        public Task<IEnumerable<ChatGroupEntity>> GetAllPublicChatGroupsAsync(
            CancellationToken cancellationToken)
        {
            return _unitOfWork.ChatGroupRepository.GetAllBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.ChatGroup.Where.IsPublic(),
                _specificationManager.ChatGroup.Select.ForDetailDisplay(),
                _specificationManager.ChatGroup.AsNoTracking);
        }

        public Task<bool> IsFoundByIdAsync(Guid chatGroupId, CancellationToken cancellationToken)
        {
            return _unitOfWork.ChatGroupRepository.IsFoundBySpecificationsAsync(
                cancellationToken: cancellationToken,
                _specificationManager.ChatGroup.Where.ById(chatGroupId));
        }

        public async Task<bool> PermanentlyRemoveAsync(
            Guid chatGroupId,
            CancellationToken cancellationToken)
        {
            var result = false;

            var executionStrategy = _unitOfWork.CreateExecutionStrategy();

            await executionStrategy.ExecuteAsync(operation: async () =>
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

                try
                {
                    await _unitOfWork.ChatGroupMemberRepository.BulkDeleteByChatGroupIdAsync(
                        chatGroupId: chatGroupId,
                        cancellationToken: cancellationToken);

                    await _unitOfWork.ChatGroupRepository.BulkDeleteByIdAsync(
                        chatGroupId: chatGroupId,
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
