using BusinessLogic.Models;
using BusinessLogic.Models.Base;
using DataAccess.Core.Entities;

namespace BusinessLogic.Services.Entities.Base
{
    public interface IAuthHandlingService
    {
        Task<IResult<UserEntity>> LoginAsync(
            string username,
            string password,
            CancellationToken cancellationToken);

        Task<bool> IsUsernameExistedAsync(string username, CancellationToken cancellationToken);

        Task<bool> IsEmailExistedAsync(string email, CancellationToken cancellationToken);

        Task<bool> RegisterAsync(RegisterInfo registerInfo, CancellationToken cancellationToken);
    }
}
