using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class AccountStatusRepository : 
    GenericRepository<AccountStatusEntity>,
    IAccountStatusRepository
{
    public AccountStatusRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
