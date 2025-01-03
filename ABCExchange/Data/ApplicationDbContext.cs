﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ABCExchange.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Change the table names for Identity tables
            builder.Entity<AppUser>().ToTable("IdentityUser");
            builder.Entity<AppRole>().ToTable("IdentityRoles");
            builder.Entity<AppUserRole>().ToTable("UserRoles");
            builder.Entity<AppUserClaim>().ToTable("UserClaims");
            builder.Entity<AppUserLogin>().ToTable("UserLogins");
            builder.Entity<AppRoleClaim>().ToTable("RoleClaims");
            builder.Entity<AppUserToken>().ToTable("UserTokens");
            builder.Entity<SeedStatus>().ToTable("SeedStatus");
            builder.Entity<Transaction>().ToTable("Transaction").Property(t => t.TransactionId).ValueGeneratedOnAdd();

            // Optional: Add any other custom configurations for entities
        }

        // Add DbSets for your other entities if required
    }
}
