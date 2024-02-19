using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class ChatGroupTypeRepository :
    GenericRepository<ChatGroupTypeEntity>,
    IChatGroupTypeRepository
{
    public ChatGroupTypeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
