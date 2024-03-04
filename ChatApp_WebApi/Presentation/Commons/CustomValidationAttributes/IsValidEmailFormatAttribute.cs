using Helpers;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Commons.CustomValidationAttributes
{
    public class IsValidEmailFormatAttribute : ValidationAttribute
    {
        public IsValidEmailFormatAttribute()
        {
            ErrorMessage = "The input email address is not valid format.";
        }

        public override bool IsValid(object value)
        {
            return EmailFormatHelper.IsCorrectFormat(value.ToString());
        }
    }
}
