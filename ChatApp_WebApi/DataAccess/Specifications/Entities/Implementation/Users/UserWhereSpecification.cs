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

        public IUserWhereSpecification ByEmail(string email)
        {
            Criteria = user => user.Email.Equals(email);

            return this;
        }

        public IUserWhereSpecification ForLogin(string username, string passwordHash)
        {
            Criteria = user => 
                user.UserName.Equals(username)
                && user.PasswordHash.Equals(passwordHash);

            return this;
        }

        public IUserWhereSpecification IsPendingStatus(Guid userId)
        {
            var accountStatusId = SeedingValues.AccountStatuses.Pending.Id;

            Criteria = user =>
                user.Id.Equals(userId)
                && user.AccountStatusId.Equals(accountStatusId);

            return this;
        }

        public IUserWhereSpecification IsEmailConfirmedStatus(Guid userId)
        {
            var accountStatusId = SeedingValues.AccountStatuses.EmailConfirmed.Id;

            Criteria = user =>
                user.Id.Equals(userId)
                && user.AccountStatusId.Equals(accountStatusId);

            return this;
        }

        public IUserWhereSpecification IsBannedStatus(Guid userId)
        {
            var accountStatusId = SeedingValues.AccountStatuses.Banned.Id;

            Criteria = user =>
                user.Id.Equals(userId)
                && user.AccountStatusId.Equals(accountStatusId);

            return this;
        }
    }
}
