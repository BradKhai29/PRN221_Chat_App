using DataAccess.Commons.SqlConstants;
using DataAccess.Core.Entities;
using DataAccess.Specifications.Entities.Base.Generics;
using DataAccess.Specifications.Entities.Implementation.RefreshTokens.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Specifications.Entities.Implementation.RefreshTokens
{
    public class RefreshTokenWhereSpecification :
        GenericSpecification<RefreshTokenEntity>,
        IRefreshTokenWhereSpecification
    {
        public IRefreshTokenWhereSpecification ForVerification(
            RefreshTokenEntity refreshToken)
        {
            Criteria = token =>
                EF.Functions.Collate(
                    token.Value,
                    SqlCollations.SqlServer.SQL_LATIN1_GENERAL_CP1_CS_AS)
                .Equals(refreshToken.Value)
                && token.AccessTokenId.Equals(refreshToken.AccessTokenId)
                && token.UserId.Equals(refreshToken.UserId);

            return this;
        }
    }
}
