using Microsoft.EntityFrameworkCore.Migrations;

namespace UniverseExplorer.Migrations
{
    public partial class RevisedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Places_PlaceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Places");

            migrationBuilder.AddColumn<string>(
                name: "PlaceName",
                table: "Places",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CharacterName",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Human",
                table: "Persons",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Places_PlaceId",
                table: "Persons",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Places_PlaceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PlaceName",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Human",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Places",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "Persons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CharacterName",
                table: "Persons",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Places_PlaceId",
                table: "Persons",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
