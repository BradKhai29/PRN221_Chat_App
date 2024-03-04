using Presentation.Commons.CustomValidationAttributes;
using Presentation.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public class RegisterDto : IDtoNormalization
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [IsValidEmailFormat]
        public string Email { get; set; }

        public void NormalizeAllProperties()
        {
            Username = Username.Trim();
            Password = Password.Trim();
            Email = Email.Trim();
        }
    }
}
