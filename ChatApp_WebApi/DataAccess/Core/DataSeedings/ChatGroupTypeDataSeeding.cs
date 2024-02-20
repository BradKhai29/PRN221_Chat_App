using DataAccess.Commons.DataSeedings;
using DataAccess.Core.DataSeedings.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.EntityDataSeedings;

internal class ChatGroupTypeDataSeeding : EntityDataSeeding<ChatGroupTypeEntity>
{
    public override void Configure(EntityTypeBuilder<ChatGroupTypeEntity> builder)
    {
        var seedEntities = GetSeedEntities();

        builder.HasData(seedEntities);
    }

    protected override List<ChatGroupTypeEntity> GetSeedEntities()
    {
        var seedEntities = new List<ChatGroupTypeEntity>(capacity: 3)
        {
            new()
            {
                Id = SeedingValues.ChatGroupTypes.OnlyMe.Id,
                Name = SeedingValues.ChatGroupTypes.OnlyMe.Name
            },
            new()
            {
                Id = SeedingValues.ChatGroupTypes.WithFriend.Id,
                Name = SeedingValues.ChatGroupTypes.WithFriend.Name
            },
            new()
            {
                Id = SeedingValues.ChatGroupTypes.WithGroup.Id,
                Name = SeedingValues.ChatGroupTypes.WithGroup.Name
            }
        };

        return seedEntities;
    }
}
