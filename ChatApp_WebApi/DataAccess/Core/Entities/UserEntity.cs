using DataAccess.Core.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Core.Entities
{
    public class UserEntity :
        IdentityUser<Guid>,
        IGuidEntity,
        ICreatedEntity,
        IUpdatedEntity
    {
        public string AvatarUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
