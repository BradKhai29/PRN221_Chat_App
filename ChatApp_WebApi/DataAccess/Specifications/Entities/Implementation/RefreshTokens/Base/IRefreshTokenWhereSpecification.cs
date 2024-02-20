using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;

namespace DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base
{
    public interface IRefreshTokenWhereSpecification :
        IGenericSpecification<RefreshTokenEntity>
    {
        IRefreshTokenWhereSpecification IsCorrectValueAndAccessTokenId(
            string value,
            Guid accessTokenId);
    }
}
