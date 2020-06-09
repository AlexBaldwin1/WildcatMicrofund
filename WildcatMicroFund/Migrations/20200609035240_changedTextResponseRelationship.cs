using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class changedTextResponseRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextResponses_Responses_ResponseID",
                table: "TextResponses");

            migrationBuilder.DropIndex(
                name: "IX_TextResponses_ResponseID",
                table: "TextResponses");

            migrationBuilder.CreateIndex(
                name: "IX_TextResponses_ResponseID",
                table: "TextResponses",
                column: "ResponseID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TextResponses_Responses_ResponseID",
                table: "TextResponses",
                column: "ResponseID",
                principalTable: "Responses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextResponses_Responses_ResponseID",
                table: "TextResponses");

            migrationBuilder.DropIndex(
                name: "IX_TextResponses_ResponseID",
                table: "TextResponses");

            migrationBuilder.CreateIndex(
                name: "IX_TextResponses_ResponseID",
                table: "TextResponses",
                column: "ResponseID");

            migrationBuilder.AddForeignKey(
                name: "FK_TextResponses_Responses_ResponseID",
                table: "TextResponses",
                column: "ResponseID",
                principalTable: "Responses",
                principalColumn: "ID");
        }
    }
}
