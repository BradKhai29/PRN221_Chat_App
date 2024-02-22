namespace BusinessLogic.Services.Entities.Base
{
    public interface IUserHandlingService
    {
        Task<bool> IsUsernameExistedAsync(string username, CancellationToken cancellationToken);

        Task<bool> IsEmailExistedAsync(string email, CancellationToken cancellationToken);
    }
}
