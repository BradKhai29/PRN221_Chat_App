using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class RefreshTokenRepository :
    GenericRepository<RefreshTokenEntity>,
    IRefreshTokenRepository
{
    public RefreshTokenRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
