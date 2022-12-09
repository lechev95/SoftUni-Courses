﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<IdentityUser> CreateUsers()
        {
            var users = new List<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = "librarian2856-c198-4129-b3f3-b893d8395082",
                UserName = "librarian@mail.com",
                NormalizedUserName = "librarian@mail.com",
                Email = "librarian@mail.com",
                NormalizedEmail = "librarian@mail.com"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "librarian123");

            user = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "client@mail.com",
                NormalizedUserName = "client@mail.com",
                Email = "client@mail.com",
                NormalizedEmail = "client@mail.com"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "client123");

            users.Add(user);
            return users;
        }
    }
}
