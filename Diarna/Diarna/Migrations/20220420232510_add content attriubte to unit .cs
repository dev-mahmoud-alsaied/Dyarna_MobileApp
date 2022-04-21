using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addcontentattriubtetounit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "tbl_units",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "tbl_units");
        }
    }
}
