using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using DataAccess.Specifications.Entities.Base.Generics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repositories.Implementation;

public class UserRoleRepository :
    GenericRepository<UserRoleEntity>,
    IUserRoleRepository
{
    public UserRoleRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
