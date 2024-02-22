﻿using DataAccess.Core;
using DataAccess.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Presentation.ExtensionMethods
{
    public static class IdentityConfiguration
    {
        private const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string UpperLetters = LowerLetters.ToUpper();
        private const string Numbers = "0123456789";
        private const string SpecialCharacters = "-._@+";
        private static readonly string AllowedCharacters = $"{LowerLetters}{UpperLetters}{Numbers}{SpecialCharacters}";

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<UserEntity, RoleEntity>(setupAction: options =>
            {
                // Password configuration.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;

                // Lockout configuration.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(value: 1);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                // User's credentials configuration.
                options.User.AllowedUserNameCharacters = $"{AllowedCharacters}";
                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ChatAppDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
