using Presentation.Commons.CustomValidationAttributes;
using Presentation.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public class InputEmailDto : IDtoNormalization
    {
        [Required]
        [IsValidEmailFormat]
        public string Email { get; set; }

        public void NormalizeAllProperties()
        {
            Email = Email.Trim();
        }
    }
}
