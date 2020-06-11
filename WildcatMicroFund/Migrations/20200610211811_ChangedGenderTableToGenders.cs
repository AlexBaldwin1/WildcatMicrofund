using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class ChangedGenderTableToGenders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gender_GenderID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Genders_GenderID",
                table: "Users",
                column: "GenderID",
                principalTable: "Genders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Genders_GenderID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gender_GenderID",
                table: "Users",
                column: "GenderID",
                principalTable: "Gender",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
