using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.Users.Base
{
    public interface IUserWhereSpecification : 
        IGenericSpecification<UserEntity>
    {
        public IUserWhereSpecification ById(Guid id);

        public IUserWhereSpecification ByUsername(string username);

        public IUserWhereSpecification IsPendingById(Guid id);

        public IUserWhereSpecification IsRegisteredById(Guid id);

        public IUserWhereSpecification IsBannedById(Guid id);
    }
}
