using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data.Context
{
    class MicroFundDatabaseContext: DbContext
    {
        public MicroFundDatabaseContext(DbContextOptions<MicroFundDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyCode> SurveyCodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }    
        public DbSet<UserBusiness> UserBusinesses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Application
            // Application User relationship
            modelBuilder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(u => u.UserID);
            // Application Business relationship
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Business)
                .WithMany(u => u.Applications)
                .HasForeignKey(u => u.BusinessID);
            // Application Survey Reference
            modelBuilder.Entity<Application>()
                .HasOne(a => a.Survey)
                .WithMany(s => s.Applications)
                .HasForeignKey(a => a.SurveyID);
                


            // Survey
            // Survey SurveyCode relationship
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.SurveyCode)
                .WithMany(sc => sc.Surveys)                
                .HasForeignKey(s => s.SurveyCodeID);

            // UserBusiness 
            // Composite key
            modelBuilder.Entity<UserBusiness>()
                .HasKey(ub => new { ub.BusinessID, ub.UserID });
            // UserBusiness User Relationship
            modelBuilder.Entity<UserBusiness>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBusinesses)
                .HasForeignKey(ub => ub.UserID);
            // UserBusiness Business relationship
            modelBuilder.Entity<UserBusiness>()
                .HasOne(ub => ub.Business)
                .WithMany(b => b.UserBusinesses)
                .HasForeignKey(ub => ub.BusinessID);

            // User Roles
            // UserRoles User relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRoleID)
                .WithOne(ur => ur.User)
                .HasForeignKey<UserRole>(u => u.ID);

            
                                                  
        }
    }
}

