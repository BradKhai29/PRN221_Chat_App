using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IUserHandlingService
    {
        Task<UserEntity> FindUserByNameAsync(string name, CancellationToken cancellationToken);
        Task<UserEntity> FindUserByEmailAsync(string email, CancellationToken cancellationToken);

        Task<bool> IsEmailConfirmedByUserIdAsync(Guid userId, CancellationToken cancellationToken);

        Task<bool> UpdatePasswordAsync(Guid userId, string password, CancellationToken cancellationToken);
    }
}
