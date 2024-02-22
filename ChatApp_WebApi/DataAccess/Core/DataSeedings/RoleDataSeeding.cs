using DataAccess.Commons.DataSeedings;
using DataAccess.Commons.SystemConstants;
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
            var systemId = DefaultValues.SystemId;

            var seedEntities = new List<RoleEntity>(capacity: 4)
            {
                new()
                {
                    Id = SeedingValues.Roles.System.Id,
                    Name = SeedingValues.Roles.System.Name,
                    NormalizedName = SeedingValues.Roles.System.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = systemId
                },
                new()
                {
                    Id = SeedingValues.Roles.User.Id,
                    Name = SeedingValues.Roles.User.Name,
                    NormalizedName = SeedingValues.Roles.User.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = systemId
                },
                new()
                {
                    Id = SeedingValues.Roles.ChatGroupMember.Id,
                    Name = SeedingValues.Roles.ChatGroupMember.Name,
                    NormalizedName = SeedingValues.Roles.ChatGroupMember.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = systemId
                },
                new()
                {
                    Id = SeedingValues.Roles.ChatGroupManager.Id,
                    Name = SeedingValues.Roles.ChatGroupManager.Name,
                    NormalizedName = SeedingValues.Roles.ChatGroupManager.Name.ToUpper(),
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = systemId
                }
            };

            return seedEntities;
        }
    }
}
