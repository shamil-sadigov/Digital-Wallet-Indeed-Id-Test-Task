using EWallet.Core.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EWallet.Persistence.Services
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Permission> Permissions{ get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> ops):base(ops)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Ignore unnecessary IdentityDbContext entities

            builder.Ignore<IdentityRole>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();

            #endregion

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
