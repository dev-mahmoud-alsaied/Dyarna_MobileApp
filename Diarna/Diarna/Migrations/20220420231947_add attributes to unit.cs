using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addattributestounit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Area",
                table: "tbl_units",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Balcon",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BeinSport",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanTakePet",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Catel",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CentralHeating",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Freidge",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Kitchen",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LookUpTheSea",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Microwave",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBeds",
                table: "tbl_units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPerson",
                table: "tbl_units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "tbl_units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfbathroom",
                table: "tbl_units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Round",
                table: "tbl_units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TV",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WashingMachine",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WiFi",
                table: "tbl_units",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Balcon",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "BeinSport",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "CanTakePet",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Catel",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "CentralHeating",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Freidge",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Kitchen",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "LookUpTheSea",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Microwave",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "NumberOfBeds",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "NumberOfPerson",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "NumberOfbathroom",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "TV",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "WashingMachine",
                table: "tbl_units");

            migrationBuilder.DropColumn(
                name: "WiFi",
                table: "tbl_units");
        }
    }
}
