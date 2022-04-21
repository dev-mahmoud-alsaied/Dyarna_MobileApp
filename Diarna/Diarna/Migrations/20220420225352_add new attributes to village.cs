using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addnewattributestovillage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AquaPark",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Billared",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cafe",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cinma",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delivery",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EntertainmentPlaces",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FishingPlaces",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Guarding",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Gym",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Hotal",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "KidsArea",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mall",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalCenter",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OpeningTheater",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PLaygrounds",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parties",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pharmacy",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PoliceStation",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Resturant",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SepcialPeach",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sowna",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SwimingPool",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TouristWalk",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WaterGaming",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WheelHire",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WomanSwimingPool",
                table: "tbl_village",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AquaPark",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Billared",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Cafe",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Cinma",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "EntertainmentPlaces",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "FishingPlaces",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Guarding",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Gym",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Hotal",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "KidsArea",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Mall",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "MedicalCenter",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "OpeningTheater",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "PLaygrounds",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Parties",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Pharmacy",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "PoliceStation",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Resturant",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "SepcialPeach",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "Sowna",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "SwimingPool",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "TouristWalk",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "WaterGaming",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "WheelHire",
                table: "tbl_village");

            migrationBuilder.DropColumn(
                name: "WomanSwimingPool",
                table: "tbl_village");
        }
    }
}
