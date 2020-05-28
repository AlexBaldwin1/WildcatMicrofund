﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WildcatMicroFund.Data.Context;

namespace WildcatMicroFund.Migrations
{
    [DbContext(typeof(WildcatMicroFundDatabaseContext))]
    partial class WildcatMicroFundDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WildcatMicroFund.Data.Models.Application", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AttendedWorkshop")
                        .HasColumnType("bit");

                    b.Property<int>("BusinessID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateApplied")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfDecision")
                        .HasColumnType("datetime2");

                    b.Property<int>("SurveyID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BusinessID");

                    b.HasIndex("SurveyID");

                    b.HasIndex("UserID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.Business", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.Survey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SurveyCodeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SurveyCodeID");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.SurveyCode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SurveyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SurveyCodes");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.UserBusiness", b =>
                {
                    b.Property<int>("BusinessID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("BusinessID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserBusinesses");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.Application", b =>
                {
                    b.HasOne("WildcatMicroFund.Data.Models.Business", "Business")
                        .WithMany("Applications")
                        .HasForeignKey("BusinessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WildcatMicroFund.Data.Models.Survey", "Survey")
                        .WithMany("Applications")
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WildcatMicroFund.Data.Models.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.Survey", b =>
                {
                    b.HasOne("WildcatMicroFund.Data.Models.SurveyCode", "SurveyCode")
                        .WithMany("Surveys")
                        .HasForeignKey("SurveyCodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.UserBusiness", b =>
                {
                    b.HasOne("WildcatMicroFund.Data.Models.Business", "Business")
                        .WithMany("UserBusinesses")
                        .HasForeignKey("BusinessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WildcatMicroFund.Data.Models.User", "User")
                        .WithMany("UserBusinesses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WildcatMicroFund.Data.Models.UserRole", b =>
                {
                    b.HasOne("WildcatMicroFund.Data.Models.User", "User")
                        .WithOne("UserRoleID")
                        .HasForeignKey("WildcatMicroFund.Data.Models.UserRole", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
