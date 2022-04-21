using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addbuildingattributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AwayFromPeach",
                table: "tbl_building",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Elvatoer",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreeParking",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FreeWifi",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "tbl_building",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "tbl_building",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrivateTransport",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceptionDesk",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SpecialGarden",
                table: "tbl_building",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayFromPeach",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "Elvatoer",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "FreeParking",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "FreeWifi",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "PrivateTransport",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "ReceptionDesk",
                table: "tbl_building");

            migrationBuilder.DropColumn(
                name: "SpecialGarden",
                table: "tbl_building");
        }
    }
}
