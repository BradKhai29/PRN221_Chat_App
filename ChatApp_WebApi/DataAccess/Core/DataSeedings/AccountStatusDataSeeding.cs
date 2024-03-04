using DataAccess.Commons.DataSeedings;
using DataAccess.Core.DataSeedings.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.DataSeedings
{
    internal class AccountStatusDataSeeding : EntityDataSeeding<AccountStatusEntity>
    {
        public override void Configure(EntityTypeBuilder<AccountStatusEntity> builder)
        {
            var seedEntities = GetSeedEntities();

            builder.HasData(seedEntities);
        }

        protected override List<AccountStatusEntity> GetSeedEntities()
        {
            var seedEntities = new List<AccountStatusEntity>(capacity: 3)
            {
                new()
                {
                    Id = SeedingValues.AccountStatuses.Pending.Id,
                    Name = SeedingValues.AccountStatuses.Pending.Name
                },
                new()
                {
                    Id = SeedingValues.AccountStatuses.EmailConfirmed.Id,
                    Name = SeedingValues.AccountStatuses.EmailConfirmed.Name
                },
                new()
                {
                    Id = SeedingValues.AccountStatuses.Banned.Id,
                    Name = SeedingValues.AccountStatuses.Banned.Name
                }
            };

            return seedEntities;
        }
    }
}
