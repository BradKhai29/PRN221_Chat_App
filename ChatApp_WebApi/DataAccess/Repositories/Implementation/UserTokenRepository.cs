using DataAccess.Core.Entities;
using DataAccess.Repositories.Base;
using DataAccess.Repositories.Base.Generics;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Implementation
{
    internal class UserTokenRepository :
        GenericRepository<UserTokenEntity>,
        IUserTokenRepository
    {
        public UserTokenRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<int> BulkDeleteForResetPasswordAsync(
            UserTokenEntity resetPasswordToken,
            CancellationToken cancellationToken)
        {
            return _dbSet
                .Where(token => 
                    token.UserId.Equals(resetPasswordToken.UserId)
                    && token.Name.Equals(resetPasswordToken.Name))
                .ExecuteDeleteAsync(cancellationToken: cancellationToken);
        }
    }
}
