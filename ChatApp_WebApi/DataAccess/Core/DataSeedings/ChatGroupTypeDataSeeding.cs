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
                Id = DataSeedingValues.ChatGroupTypes.OnlyMe.Id,
                Name = DataSeedingValues.ChatGroupTypes.OnlyMe.Name
            },
            new()
            {
                Id = DataSeedingValues.ChatGroupTypes.WithFriend.Id,
                Name = DataSeedingValues.ChatGroupTypes.WithFriend.Name
            },
            new()
            {
                Id = DataSeedingValues.ChatGroupTypes.WithGroup.Id,
                Name = DataSeedingValues.ChatGroupTypes.WithGroup.Name
            }
        };

        return seedEntities;
    }
}
