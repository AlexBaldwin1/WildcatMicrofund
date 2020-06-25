using Microsoft.EntityFrameworkCore.Migrations;

namespace WildcatMicrofund.Migrations
{
    public partial class AllowNullOnChoiceID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceResponses_Choices_ChoiceID",
                table: "MultipleChoiceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleChoiceResponses_Choices_ChoiceID",
                table: "SingleChoiceResponses");

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceID",
                table: "SingleChoiceResponses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceID",
                table: "MultipleChoiceResponses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceResponses_Choices_ChoiceID",
                table: "MultipleChoiceResponses",
                column: "ChoiceID",
                principalTable: "Choices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleChoiceResponses_Choices_ChoiceID",
                table: "SingleChoiceResponses",
                column: "ChoiceID",
                principalTable: "Choices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceResponses_Choices_ChoiceID",
                table: "MultipleChoiceResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleChoiceResponses_Choices_ChoiceID",
                table: "SingleChoiceResponses");

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceID",
                table: "SingleChoiceResponses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoiceID",
                table: "MultipleChoiceResponses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceResponses_Choices_ChoiceID",
                table: "MultipleChoiceResponses",
                column: "ChoiceID",
                principalTable: "Choices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleChoiceResponses_Choices_ChoiceID",
                table: "SingleChoiceResponses",
                column: "ChoiceID",
                principalTable: "Choices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
