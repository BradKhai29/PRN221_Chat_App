using Presentation.DTOs.Base;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public sealed class LoginDto : IDtoNormalization
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public void NormalizeAllProperties()
        {
            Username = Username.Trim();
            Password = Password.Trim();
        }
    }
}
