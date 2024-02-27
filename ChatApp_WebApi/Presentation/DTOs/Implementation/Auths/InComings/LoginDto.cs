﻿using Presentation.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace Presentation.DTOs.Implementation.Auths.InComings
{
    public sealed class LoginDto : IDtoNormalization
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }

        public void NormalizeAllProperties()
        {
            Username = Username.Trim();
            Password = Password.Trim();
        }
    }
}
