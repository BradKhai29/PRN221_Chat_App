using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Repositories.Base
{
    public interface IUserRepository
        : IBaseIdentityRepository<UserEntity, Guid>
    {
        Task<UserEntity> FindByUsernameAsync(string username);

        UserManager<UserEntity> Manager { get; }
    }
}
