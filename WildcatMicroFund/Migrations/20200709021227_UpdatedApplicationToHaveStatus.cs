using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class UpdatedApplicationToHaveStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "MentorID",
                table: "Businesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatusID",
                table: "Applications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationStatusID1",
                table: "Applications",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_MentorID",
                table: "Businesses",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationStatusID1",
                table: "Applications",
                column: "ApplicationStatusID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusID1",
                table: "Applications",
                column: "ApplicationStatusID1",
                principalTable: "ApplicationStatuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Users_MentorID",
                table: "Businesses",
                column: "MentorID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStatuses_ApplicationStatusID1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Users_MentorID",
                table: "Businesses");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_MentorID",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationStatusID1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "MentorID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusID1",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
