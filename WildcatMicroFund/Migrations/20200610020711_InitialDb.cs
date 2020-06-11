using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.ID);
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
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTypeName = table.Column<string>(type: "varchar(500)", nullable: false),
                    QuestionTypeHasChoices = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyCodes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyCodes", x => x.ID);
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
                        name: "FK_Users_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyCodeID = table.Column<int>(nullable: false),
                    QuestionText = table.Column<string>(type: "varchar(500)", nullable: true),
                    QuestionNumber = table.Column<int>(nullable: false),
                    QuestionTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_QuestionTypeID",
                        column: x => x.QuestionTypeID,
                        principalTable: "QuestionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_SurveyCodes_SurveyCodeID",
                        column: x => x.SurveyCodeID,
                        principalTable: "SurveyCodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyCodeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Surveys_SurveyCodes_SurveyCodeID",
                        column: x => x.SurveyCodeID,
                        principalTable: "SurveyCodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBusinesses",
                columns: table => new
                {
                    BusinessID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinesses", x => new { x.BusinessID, x.UserID });
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

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RoleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceText = table.Column<string>(type: "varchar(500)", nullable: true),
                    QuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
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
                    SurveyID = table.Column<int>(nullable: false),
                    ApplicationStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Applications_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
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
                name: "Responses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseDate = table.Column<DateTime>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Responses_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    ResponseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateResponses", x => new { x.QuestionID, x.ResponseID });
                    table.ForeignKey(
                        name: "FK_DateResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DateResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceResponses",
                columns: table => new
                {
                    ChoiceID = table.Column<int>(nullable: false),
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceResponses", x => new { x.ChoiceID, x.ResponseID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_MultipleChoiceResponses_Choices_ChoiceID",
                        column: x => x.ChoiceID,
                        principalTable: "Choices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MultipleChoiceResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NumericResponses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    ResponseNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumericResponses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NumericResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumericResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SingleChoiceResponses",
                columns: table => new
                {
                    ChoiceID = table.Column<int>(nullable: false),
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleChoiceResponses", x => new { x.ChoiceID, x.ResponseID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_SingleChoiceResponses_Choices_ChoiceID",
                        column: x => x.ChoiceID,
                        principalTable: "Choices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleChoiceResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SingleChoiceResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TextResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    ResponseText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextResponses", x => new { x.QuestionID, x.ResponseID });
                    table.ForeignKey(
                        name: "FK_TextResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "YesNoResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    YesNoResponseValue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YesNoResponses", x => new { x.QuestionID, x.ResponseID });
                    table.ForeignKey(
                        name: "FK_YesNoResponses_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YesNoResponses_Responses_ResponseID",
                        column: x => x.ResponseID,
                        principalTable: "Responses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_BusinessID",
                table: "Applications",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SurveyID",
                table: "Applications",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                table: "Applications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionID",
                table: "Choices",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_DateResponses_ResponseID",
                table: "DateResponses",
                column: "ResponseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceResponses_QuestionID",
                table: "MultipleChoiceResponses",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceResponses_ResponseID",
                table: "MultipleChoiceResponses",
                column: "ResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_NumericResponses_QuestionID",
                table: "NumericResponses",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_NumericResponses_ResponseID",
                table: "NumericResponses",
                column: "ResponseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionTypeID",
                table: "Questions",
                column: "QuestionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyCodeID",
                table: "Questions",
                column: "SurveyCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_SurveyID",
                table: "Responses",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SingleChoiceResponses_QuestionID",
                table: "SingleChoiceResponses",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SingleChoiceResponses_ResponseID",
                table: "SingleChoiceResponses",
                column: "ResponseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_SurveyCodeID",
                table: "Surveys",
                column: "SurveyCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_TextResponses_ResponseID",
                table: "TextResponses",
                column: "ResponseID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBusinesses_UserID",
                table: "UserBusinesses",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EthnicityID",
                table: "Users",
                column: "EthnicityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderID",
                table: "Users",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_YesNoResponses_ResponseID",
                table: "YesNoResponses",
                column: "ResponseID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "DateResponses");

            migrationBuilder.DropTable(
                name: "MultipleChoiceResponses");

            migrationBuilder.DropTable(
                name: "NumericResponses");

            migrationBuilder.DropTable(
                name: "SingleChoiceResponses");

            migrationBuilder.DropTable(
                name: "TextResponses");

            migrationBuilder.DropTable(
                name: "UserBusinesses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "YesNoResponses");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Ethnicities");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "SurveyCodes");
        }
    }
}
