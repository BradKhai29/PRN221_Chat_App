using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.Users.Base
{
    public interface IUserWhereSpecification :
        IGenericSpecification<UserEntity>
    {
        IUserWhereSpecification ById(Guid id);

        IUserWhereSpecification ByUsername(string username);

        IUserWhereSpecification ByEmail(string email);

        IUserWhereSpecification ForLogin(string username, string passwordHash);

        IUserWhereSpecification IsPendingById(Guid id);

        IUserWhereSpecification IsRegisteredById(Guid id);

        IUserWhereSpecification IsBannedById(Guid id);
    }
}
