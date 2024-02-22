namespace BusinessLogic.Services.Externals.Base
{
    public interface IMailHandlingService
    {
        Task<bool> IsRealAsync(string email);
    }
}
