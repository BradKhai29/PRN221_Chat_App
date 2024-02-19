using DataAccess.Commons.DataSeedings;
using DataAccess.Core.DataSeedings.Base;
using DataAccess.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Core.DataSeedings
{
    internal class RoleDataSeeding : EntityDataSeeding<RoleEntity>
    {
        public override void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            var seedEntities = GetSeedEntities();

            builder.HasData(seedEntities);
        }

        protected override List<RoleEntity> GetSeedEntities()
        {
            var seedEntities = new List<RoleEntity>(capacity: 4)
            {
                new()
                {
                    Id = DataSeedingValues.Roles.System.Id,
                    Name = DataSeedingValues.Roles.System.Name,
                    NormalizedName = DataSeedingValues.Roles.System.Name.ToUpper()
                },
                new()
                {
                    Id = DataSeedingValues.Roles.User.Id,
                    Name = DataSeedingValues.Roles.User.Name,
                    NormalizedName = DataSeedingValues.Roles.User.Name.ToUpper()
                },
                new()
                {
                    Id = DataSeedingValues.Roles.ChatGroupMember.Id,
                    Name = DataSeedingValues.Roles.ChatGroupMember.Name,
                    NormalizedName = DataSeedingValues.Roles.ChatGroupMember.Name.ToUpper()
                },
                new()
                {
                    Id = DataSeedingValues.Roles.ChatGroupManager.Id,
                    Name = DataSeedingValues.Roles.ChatGroupManager.Name,
                    NormalizedName = DataSeedingValues.Roles.ChatGroupManager.Name.ToUpper()
                }
            };

            return seedEntities;
        }
    }
}
