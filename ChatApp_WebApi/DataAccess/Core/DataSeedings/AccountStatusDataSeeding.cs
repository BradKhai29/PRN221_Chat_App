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
                    Id = DataSeedingValues.AccountStatuses.Pending.Id,
                    Name = DataSeedingValues.AccountStatuses.Pending.Name
                },
                new()
                {
                    Id = DataSeedingValues.AccountStatuses.Registered.Id,
                    Name = DataSeedingValues.AccountStatuses.Registered.Name
                },
                new()
                {
                    Id = DataSeedingValues.AccountStatuses.Banned.Id,
                    Name = DataSeedingValues.AccountStatuses.Banned.Name
                }
            };

            return seedEntities;
        }
    }
}
