﻿using app.Domain.Models;
using app.Domain.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace app.RepositoryAdapter
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfilePermission> ProfilePermissions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            /*modelBuilder.Entity<ProfilePermission>()
                .HasKey(pp => new { pp.ProfileId, pp.PermissionId });

            modelBuilder.Entity<ProfilePermission>()
                .HasOne(pp => pp.Profile)
                .WithMany()
                .HasForeignKey(pp => pp.ProfileId);

            modelBuilder.Entity<ProfilePermission>()
                .HasOne(pp => pp.Permission)
                .WithMany()
                .HasForeignKey(pp => pp.PermissionId);*/
        }
    }
}