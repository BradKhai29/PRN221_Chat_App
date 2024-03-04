using BusinessLogic.Services.Entities.Base;
using DataAccess.Core;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Managers.SuperManager.Base;
using DataAccess.UnitOfWorks.Base;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services.Entities.Implementation;

public class ChatMessageHandlingService :
    IChatMessageHandlingService
{

    // Backing fields.
    private readonly IUnitOfWork<ChatAppDbContext> _unitOfWork;
    private readonly ISuperSpecificationManager _specificationManager;

    public ChatMessageHandlingService(
        IUnitOfWork<ChatAppDbContext> unitOfWork,
        ISuperSpecificationManager specificationManager)
    {
        _specificationManager = specificationManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateAsync(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        var result = false;

        var executionStrategy = _unitOfWork.CreateExecutionStrategy();

        await executionStrategy.ExecuteAsync(operation: async () =>
        {
            await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

            try
            {
                await _unitOfWork.ChatMessageRepository.AddAsync(
                    newEntity: chatMessage,
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

    public async Task<bool> RemoveAsync(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        var result = false;

        var executionStrategy = _unitOfWork.CreateExecutionStrategy();

        await executionStrategy.ExecuteAsync(operation: async () =>
        {
            await _unitOfWork.CreateTransactionAsync(cancellationToken: cancellationToken);

            try
            {
                _unitOfWork.ChatMessageRepository.Remove(foundEntity: chatMessage);

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

    public Task<bool> UpdateContentAsync(
        ChatMessageEntity chatMessage,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateReplyMessageAsync(
        ChatMessageEntity replyMessage,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
