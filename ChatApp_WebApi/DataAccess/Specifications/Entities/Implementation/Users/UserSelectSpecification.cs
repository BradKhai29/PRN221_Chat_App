using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.Users.Base;

namespace DataAccess.Specifications.Entities.Implementation.Users
{
    public class UserSelectSpecification :
        GenericSpecification<UserEntity>,
        IUserSelectSpecification
    {
        public IUserSelectSpecification ForDetailDisplay()
        {
            SelectExpression = user => new UserEntity
            {
                Id = user.Id,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                Gender = user.Gender,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };

            return this;
        }
    }
}
