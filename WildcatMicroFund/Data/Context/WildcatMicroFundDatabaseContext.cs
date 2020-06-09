using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WildcatMicroFund.Data.Models;

namespace WildcatMicroFund.Data.Context
{
    public class WildcatMicroFundDatabaseContext: DbContext
    {
        public WildcatMicroFundDatabaseContext(DbContextOptions<WildcatMicroFundDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyCode> SurveyCodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }    
        public DbSet<UserBusiness> UserBusinesses { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<DateResponse> DateResponses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<TextResponse> TextResponses { get; set; }
        
        

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

            // Date Response
            modelBuilder.Entity<DateResponse>()
                .HasKey(dr => new { dr.QuestionID, dr.ResponseID });
            modelBuilder.Entity<DateResponse>()
                .HasOne(dr => dr.Response)
                .WithOne(r => r.DateResponse)
                .HasForeignKey<Response>(r=> r.DateResponseID);


            // Question
            // Question Survey relationship
            modelBuilder.Entity<Question>()
               .HasOne(q => q.SurveyCode)
               .WithMany(sc => sc.Questions)
               .HasForeignKey(s => s.SurveyCodeID);

            // QuestionType
            // Question type Question relationship
            modelBuilder.Entity<Question>()
               .HasOne(q => q.QuestionType)
               .WithMany(qt => qt.Questions)
               .HasForeignKey(q => q.QuestionTypeID);


            // Survey
            // Survey SurveyCode relationship
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.SurveyCode)
                .WithMany(sc => sc.Surveys)                
                .HasForeignKey(s => s.SurveyCodeID);


            // Text Response
            modelBuilder.Entity<TextResponse>()
                .HasKey(tr => new { tr.QuestionID, tr.ResponseID });
            modelBuilder.Entity<TextResponse>()
                .HasOne(tr => tr.Response)
                .WithOne(r => r.TextResponse)
                .HasForeignKey<Response>(r => r.TextResponseID);


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
                .HasForeignKey<UserRole>(ur => ur.ID);

            //User
            //User Ethnicity relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Ethnicity)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EthnicityID);

        }
    }
}

