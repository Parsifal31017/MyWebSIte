using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyWebSite.Models;
using System.Security.Claims;
using MyWebSite.Pages.Company;
//using Google.Apis.YouTube.Samples;

namespace MyWebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<AdminAssignment> AdminAssignment { get; set; }
        public DbSet<YouTubeImageCount> YouTubeImageCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<AdminAssignment>().ToTable("AdminAssigment ");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AdminAssignment>()
                .HasKey(c => new { c.UserID, c.AdminID });

            modelBuilder
    .Entity<YouTubeImageCount>(eb =>
    {
        eb.HasNoKey();
        eb.ToView("View_YouTubeImageCounts");
        eb.Property(v => v.UploadFileSample).HasColumnName("Name");
    });
        }
    }
}
