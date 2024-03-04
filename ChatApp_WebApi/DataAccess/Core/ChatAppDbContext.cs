using DataAccess.Core.Configurations;
using DataAccess.Core.DataSeedings;
using DataAccess.Core.Entities;
using DataAccess.Core.EntityDataSeedings;
using Helpers.ExtensionMethods;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataAccess.Core;

public class ChatAppDbContext :
    IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    // public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options)
    //        : base(options)
    // {
    // }

    public ChatAppDbContext() : base()
    {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {

    //     var connectionString = "Data Source=localhost;Initial Catalog=ChatApp_PRN221;User ID=sa;Password=123123;Trust Server Certificate=True";
    //     optionsBuilder.UseSqlServer(connectionString);
    //     optionsBuilder.UseLoggerFactory(GetLoggerFactory());
    // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // IdentityServer default configuration.
        base.OnModelCreating(builder);

        RemoveAspNetPrefixInIdentityTable(builder);

        // ChatApp entities configuration.
        ApplyEntityConfiguration(builder);

        // ChatApp data seeding.
        ApplyEntityDataSeeding(builder);
    }

    private void RemoveAspNetPrefixInIdentityTable(ModelBuilder builder)
    {
        const string AspNetPrefix = "AspNet";
        int index = AspNetPrefix.Length;

        builder.Model
            .GetEntityTypes()
            .ForEach(action: entityType =>
            {
                var tableName = entityType.GetTableName();

                if (tableName.StartsWith(value: AspNetPrefix))
                {
                    entityType.SetTableName(name: $"{tableName[index..]}");
                }
            });
    }

    private void ApplyEntityConfiguration(ModelBuilder builder)
    {
        // Identity server section.
        builder
            .ApplyConfiguration(new UserEntityConfiguration())
            .ApplyConfiguration(new RoleEntityConfiguration())
            .ApplyConfiguration(new RoleClaimEntityConfiguration())
            .ApplyConfiguration(new UserRoleEntityConfiguration())
            .ApplyConfiguration(new UserClaimEntityConfiguration())
            .ApplyConfiguration(new UserTokenEntityConfiguration())
            .ApplyConfiguration(new UserLoginEntityConfiguration());

        // Chat section.
        builder
            .ApplyConfiguration(new AccountStatusEntityConfiguration())
            .ApplyConfiguration(new ChatGroupTypeEntityConfiguration())
            .ApplyConfiguration(new ChatGroupEntityConfiguration())
            .ApplyConfiguration(new ChatGroupMemberEntityConfiguration())
            .ApplyConfiguration(new ChatMessageEntityConfiguration())
            .ApplyConfiguration(new RefreshTokenEntityConfiguration());
    }

    private void ApplyEntityDataSeeding(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new AccountStatusDataSeeding())
            .ApplyConfiguration(new ChatGroupTypeDataSeeding());
    }

    private static ILoggerFactory GetLoggerFactory()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
                builder.AddConsole()
                       .AddFilter(DbLoggerCategory.Database.Command.Name,
                                LogLevel.Information));

        return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
    }
}
