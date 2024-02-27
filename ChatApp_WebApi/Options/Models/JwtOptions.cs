﻿using Helpers;
using Microsoft.IdentityModel.Tokens;
using Options.Commons.Constants;

namespace Options.Models
{
    public sealed class JwtOptions
    {
        public const string ParentSectionName = AuthenticationSection.Name;
        public const string SectionName = "Jwt";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string PrivateKey { get; set; }

        /// <summary>
        ///     The number of days this token will live in short term.
        /// </summary>
        public int DefaultShortLiveDays { get; set; }

        /// <summary>
        ///     The number of days this token will live in long term.
        /// </summary>
        public int DefaultLongLiveDays { get; set; }

        public byte[] GetKey()
        {
            return JwtTokenHelper.Encrypt(key: PrivateKey);
        }

        public SymmetricSecurityKey GetSecurityKey()
        {
            var encryptedKey = GetKey();

            return new SymmetricSecurityKey(key: encryptedKey);
        }

        public TimeSpan GetLifeSpan(bool isLongLive)
        {
            if (isLongLive)
            {
                return TimeSpan.FromDays(DefaultLongLiveDays);
            }

            return TimeSpan.FromDays(DefaultShortLiveDays);
        }

        public TimeSpan GetLongLifeSpan()
        {
            return TimeSpan.FromDays(DefaultLongLiveDays);
        }

        public TimeSpan GetShortLifeSpan()
        {
            return TimeSpan.FromDays(DefaultShortLiveDays);
        }
    }
}
