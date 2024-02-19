using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Implementation;
using DataAccess.UnitOfWorks.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.UnitOfWorks.Implementations;

public class ChatAppUnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
{
    // Backing stores.
    private readonly TContext _dbContext;
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<RoleEntity> _roleManager;

    // Backing fields for transaction handling.
    private IDbContextTransaction _dbTransaction;

    // Backing fields for implement UnitOfWork Repository Provider.
    private IAccountStatusRepository _accountStatusRepository;
    private IUserRepository _userRepository;
    private IRoleRepository _roleRepository;
    private IUserRoleRepository _userRoleRepository;
    private IChatGroupTypeRepository _chatGroupTypeRepository;
    private IChatGroupRepository _chatGroupRepository;
    private IChatGroupMemberRepository _chatGroupMemberRepository;
    private IChatMessageRepository _chatMessageRepository;
    private IRefreshTokenRepository _refreshTokenRepository;

    // Properties.
    public IAccountStatusRepository AccountStatusRepository
    {
        get
        {
            _accountStatusRepository ??= new AccountStatusRepository(_dbContext);
            return _accountStatusRepository;
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            _userRepository ??= new UserRepository(_dbContext, _userManager);
            return _userRepository;
        }
    }

    public IRoleRepository RoleRepository
    {
        get
        {
            _roleRepository ??= new RoleRepository(_dbContext, _roleManager);
            return _roleRepository;
        }
    }

    public IUserRoleRepository UserRoleRepository
    {
        get
        {
            _userRoleRepository ??= new UserRoleRepository(_dbContext);
            return _userRoleRepository;
        }
    }

    public IChatGroupTypeRepository ChatGroupTypeRepository
    {
        get
        {
            _chatGroupTypeRepository ??= new ChatGroupTypeRepository(_dbContext);
            return _chatGroupTypeRepository;
        }
    }

    public IChatGroupRepository ChatGroupRepository
    {
        get
        {
            _chatGroupRepository ??= new ChatGroupRepository(_dbContext);
            return _chatGroupRepository;
        }
    }

    public IChatMessageRepository ChatMessageRepository
    {
        get
        {
            _chatMessageRepository ??= new ChatMessageRepository(_dbContext);
            return _chatMessageRepository;
        }
    }

    public IChatGroupMemberRepository ChatGroupMemberRepository
    {
        get
        {
            _chatGroupMemberRepository ??= new ChatGroupMemberRepository(_dbContext);
            return _chatGroupMemberRepository;
        }
    }

    public IRefreshTokenRepository RefreshTokenRepository
    {
        get
        {
            _refreshTokenRepository ??= new RefreshTokenRepository(_dbContext);
            return _refreshTokenRepository;
        }
    }

    public ChatAppUnitOfWork(
        TContext dbContext,
        UserManager<UserEntity> userManager,
        RoleManager<RoleEntity> roleManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _dbContext.Database.CreateExecutionStrategy();
    }

    public async Task CreateTransactionAsync(CancellationToken cancellationToken)
    {
        _dbTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.CommitAsync(cancellationToken);
    }

    public ValueTask DisposeTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.DisposeAsync();
    }

    public Task RollBackTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbTransaction.RollbackAsync(cancellationToken);
    }

    public Task SaveChangesToDatabaseAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}