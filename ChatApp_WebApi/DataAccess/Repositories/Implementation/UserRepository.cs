using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using DataAccess.Specifications.Entities.Base.Generics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class UserRepository :
    BaseIdentityRepository<UserEntity>,
    IUserRepository
{
    private readonly UserManager<UserEntity> _userManager;

    public UserRepository(
        DbContext dbContext,
        UserManager<UserEntity> userManager) : base(dbContext)
    {
        _userManager = userManager;
    }

    public override Task<IdentityResult> AddAsync(UserEntity newEntity)
    {
        return _userManager.CreateAsync(newEntity);
    }

    public override Task<UserEntity> FindByIdAsync(Guid id)
    {
        return _userManager.FindByIdAsync(id.ToString());
    }

    public override Task<UserEntity> FindByNameAsync(string username)
    {
        return _userManager.FindByNameAsync(username);
    }

    public override async Task<IdentityResult> RemoveAsync(Guid id)
    {
        var foundUser = await _userManager.FindByIdAsync(id.ToString());

        return await _userManager.DeleteAsync(foundUser);
    }

    public override Task<IdentityResult> UpdateAsync(UserEntity foundEntity)
    {
        return _userManager.UpdateAsync(foundEntity);
    }
}
