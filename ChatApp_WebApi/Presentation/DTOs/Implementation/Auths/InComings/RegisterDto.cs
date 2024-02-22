using Presentation.DTOs.Base;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public class RegisterDto : IDtoNormalization
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public void NormalizeAllProperties()
        {
            Username = Username.Trim();
            Password = Password.Trim();
            Email = Email.Trim();
        }
    }
}
