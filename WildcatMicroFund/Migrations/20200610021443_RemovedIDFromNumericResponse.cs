using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class RemovedIDFromNumericResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NumericResponses",
                table: "NumericResponses");

            migrationBuilder.DropIndex(
                name: "IX_NumericResponses_QuestionID",
                table: "NumericResponses");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "NumericResponses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumericResponses",
                table: "NumericResponses",
                columns: new[] { "QuestionID", "ResponseID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NumericResponses",
                table: "NumericResponses");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "NumericResponses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NumericResponses",
                table: "NumericResponses",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_NumericResponses_QuestionID",
                table: "NumericResponses",
                column: "QuestionID");
        }
    }
}
