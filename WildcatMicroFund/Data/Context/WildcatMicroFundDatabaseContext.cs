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
       
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }    
        public DbSet<UserBusiness> UserBusinesses { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<IdeaApplication> IdeaApplications { get; set; }
        public DbSet<BusinessStage> BusinessStages { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<ConceptStatus> ConceptStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
             
        }


    }
}

