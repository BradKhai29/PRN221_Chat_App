using DataAccess.Core.Entities;
using DataAccess.Repositories.Base.Generics;

namespace DataAccess.Repositories.Base;

public interface IUserTokenRepository :
    IGenericRepository<UserTokenEntity>
{
    Task<int> BulkDeleteForResetPasswordAsync(
        UserTokenEntity resetPasswordToken,
        CancellationToken cancellationToken);
}
