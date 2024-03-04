using Presentation.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public class ResetPasswordDto : IDtoNormalization
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(otherProperty: nameof(Password))]
        public string AgainPassword { get; set; }
        
        [Required]
        public string Token { get; set; }

        public void NormalizeAllProperties()
        {
            Password = Password.Trim();
        }
    }
}
