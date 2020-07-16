using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class RemovedApplicationApplicationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationApplicationDetails_ApplicationApplicationDetailID",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "ApplicationApplicationDetails");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationApplicationDetailID",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicationApplicationDetailID",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationID",
                table: "ApplicationDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateChanged",
                table: "ApplicationDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ApplicationID",
                table: "ApplicationDetails",
                column: "ApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationID",
                table: "ApplicationDetails",
                column: "ApplicationID",
                principalTable: "Applications",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationDetails_Applications_ApplicationID",
                table: "ApplicationDetails");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationDetails_ApplicationID",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationID",
                table: "ApplicationDetails");

            migrationBuilder.DropColumn(
                name: "DateChanged",
                table: "ApplicationDetails");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationApplicationDetailID",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationApplicationDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDetailID = table.Column<int>(type: "int", nullable: true),
                    DateChange = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationApplicationDetailID",
                table: "Applications",
                column: "ApplicationApplicationDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationApplicationDetails_ApplicationDetailID",
                table: "ApplicationApplicationDetails",
                column: "ApplicationDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationApplicationDetails_ApplicationApplicationDetailID",
                table: "Applications",
                column: "ApplicationApplicationDetailID",
                principalTable: "ApplicationApplicationDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
