﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExamFinalCibertec.Models
{
    public class WebDeveloperUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<WebDeveloperUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class WebDeveloperDbContext : IdentityDbContext<WebDeveloperUser>
    {
        public WebDeveloperDbContext()
            : base("IdentityConnectionString")
        {
        }

        public static WebDeveloperDbContext Create()
        {
            return new WebDeveloperDbContext();
        }
    }
}
