using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessStages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessStageDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessStages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConceptStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConceptStatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EthnicityDescription = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concept = table.Column<string>(nullable: true),
                    ConceptStatusID = table.Column<int>(nullable: false),
                    SalesGenerated = table.Column<bool>(nullable: false),
                    SalesGeneratedInformation = table.Column<string>(nullable: true),
                    BusinessStageID = table.Column<int>(nullable: false),
                    BusinessIdeaDescription = table.Column<string>(nullable: true),
                    HasPrototypeOrIntellectualProperty = table.Column<bool>(nullable: false),
                    PrototypeDescription = table.Column<string>(nullable: true),
                    BusinessTypeID = table.Column<int>(nullable: false),
                    MarketOpportunity = table.Column<string>(nullable: true),
                    EvidenceOfViableOpportunity = table.Column<string>(nullable: true),
                    CustomerDescription = table.Column<string>(nullable: true),
                    MarketingAndSales = table.Column<string>(nullable: true),
                    BusinessCosts = table.Column<string>(nullable: true),
                    CompetitionDescription = table.Column<string>(nullable: true),
                    TeamDescription = table.Column<string>(nullable: true),
                    SpecificRequest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_BusinessStages_BusinessStageID",
                        column: x => x.BusinessStageID,
                        principalTable: "BusinessStages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_BusinessTypes_BusinessTypeID",
                        column: x => x.BusinessTypeID,
                        principalTable: "BusinessTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_ConceptStatuses_ConceptStatusID",
                        column: x => x.ConceptStatusID,
                        principalTable: "ConceptStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(400)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    GenderID = table.Column<int>(nullable: false),
                    EthnicityID = table.Column<int>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Ethnicities_EthnicityID",
                        column: x => x.EthnicityID,
                        principalTable: "Ethnicities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Genders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationApplicationDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateChange = table.Column<DateTime>(nullable: false),
                    ApplicationDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationApplicationDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationApplicationDetails_ApplicationDetails_ApplicationDetailID",
                        column: x => x.ApplicationDetailID,
                        principalTable: "ApplicationDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: true),
                    MentorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Businesses_Users_MentorID",
                        column: x => x.MentorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DateApplied = table.Column<DateTime>(nullable: false),
                    AttendedWorkshop = table.Column<bool>(nullable: false),
                    DateOfDecision = table.Column<DateTime>(nullable: false),
                    ApplicationApplicationDetailID = table.Column<int>(nullable: false),
                    ApplicationStatusID = table.Column<string>(nullable: true),
                    ApplicationStatusID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationApplicationDetails_ApplicationApplicationDetailID",
                        column: x => x.ApplicationApplicationDetailID,
                        principalTable: "ApplicationApplicationDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_ApplicationStatuses_ApplicationStatusID1",
                        column: x => x.ApplicationStatusID1,
                        principalTable: "ApplicationStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBusinesses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinesses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserBusinesses_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBusinesses_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApplicationDetails_ApplicationDetailID",
                table: "ApplicationApplicationDetails",
                column: "ApplicationDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_BusinessStageID",
                table: "ApplicationDetails",
                column: "BusinessStageID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_BusinessTypeID",
                table: "ApplicationDetails",
                column: "BusinessTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ConceptStatusID",
                table: "ApplicationDetails",
                column: "ConceptStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationApplicationDetailID",
                table: "Applications",
                column: "ApplicationApplicationDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusID1",
                table: "Applications",
                column: "ApplicationStatusID1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_BusinessID",
                table: "Applications",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                table: "Applications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_MentorID",
                table: "Businesses",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinesses_BusinessID",
                table: "UserBusinesses",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinesses_UserID",
                table: "UserBusinesses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EthnicityID",
                table: "Users",
                column: "EthnicityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderID",
                table: "Users",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "UserBusinesses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ApplicationApplicationDetails");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ApplicationDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BusinessStages");

            migrationBuilder.DropTable(
                name: "BusinessTypes");

            migrationBuilder.DropTable(
                name: "ConceptStatuses");

            migrationBuilder.DropTable(
                name: "Ethnicities");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
