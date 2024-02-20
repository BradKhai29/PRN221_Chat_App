using DataAccess.Commons.DataSeedings;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.Users.Base;

namespace DataAccess.Specifications.Entities.Implementation.Users
{
    public class UserWhereSpecification :
        GenericSpecification<UserEntity>,
        IUserWhereSpecification
    {
        public IUserWhereSpecification ById(Guid id)
        {
            Criteria = user => user.Id.Equals(id);

            return this;
        }

        public IUserWhereSpecification ByUsername(string username)
        {
            Criteria = user => user.UserName.Equals(username);

            return this;
        }

        public IUserWhereSpecification IsPendingById(Guid id)
        {
            Criteria = user =>
                user.Id.Equals(id)
                && user.AccountStatusId.Equals(SeedingValues.AccountStatuses.Pending.Id);

            return this;
        }

        public IUserWhereSpecification IsRegisteredById(Guid id)
        {
            Criteria = user =>
                user.Id.Equals(id)
                && user.AccountStatusId.Equals(SeedingValues.AccountStatuses.Registered.Id);

            return this;
        }

        public IUserWhereSpecification IsBannedById(Guid id)
        {
            Criteria = user =>
                user.Id.Equals(id)
                && user.AccountStatusId.Equals(SeedingValues.AccountStatuses.Registered.Id);

            return this;
        }
    }
}
