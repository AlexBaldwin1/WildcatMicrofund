using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class adjustedResponseRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DateResponses_ResponseID",
                table: "DateResponses");

            migrationBuilder.CreateIndex(
                name: "IX_DateResponses_ResponseID",
                table: "DateResponses",
                column: "ResponseID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DateResponses_ResponseID",
                table: "DateResponses");

            migrationBuilder.CreateIndex(
                name: "IX_DateResponses_ResponseID",
                table: "DateResponses",
                column: "ResponseID");
        }
    }
}
