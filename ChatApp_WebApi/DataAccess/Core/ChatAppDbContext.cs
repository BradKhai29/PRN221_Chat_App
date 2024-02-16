using Microsoft.EntityFrameworkCore;

namespace DataAccess.Core;

public class ChatAppDbContext : DbContext
{
    public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "";
        optionsBuilder.UseSqlServer(connectionString);
    }
}
