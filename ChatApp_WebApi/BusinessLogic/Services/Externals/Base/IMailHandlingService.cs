using BusinessLogic.Models;

namespace BusinessLogic.Services.Externals.Base
{
    public interface IMailHandlingService
    {
        /// <summary>
        ///     Verify if email address is really existed or not.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        ///     The result (bool) of verifying the existence of input email address.
        /// </returns>
        Task<bool> IsRealAsync(string email);

        Task<MailContentModel> GetMailContentAsync(
            string templatePath,
            string to,
            string subject,
            string linkedUri1,
            string linkedUri2,
            CancellationToken cancellationToken);

        Task<bool> SendMailAsync(MailContentModel mailContent);
    }
}
