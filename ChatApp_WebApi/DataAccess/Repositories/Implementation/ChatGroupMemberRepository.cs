using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation;

public class ChatGroupMemberRepository :
    GenericRepository<ChatGroupMemberEntity>,
    IChatGroupMemberRepository
{
    public ChatGroupMemberRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
