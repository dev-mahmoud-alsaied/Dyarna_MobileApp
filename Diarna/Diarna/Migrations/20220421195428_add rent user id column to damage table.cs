using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addrentuseridcolumntodamagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentUserId",
                table: "TblUnitDamages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblUnitDamages_RentUserId",
                table: "TblUnitDamages",
                column: "RentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblUnitDamages_tbl_rentUsers_RentUserId",
                table: "TblUnitDamages",
                column: "RentUserId",
                principalTable: "tbl_rentUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblUnitDamages_tbl_rentUsers_RentUserId",
                table: "TblUnitDamages");

            migrationBuilder.DropIndex(
                name: "IX_TblUnitDamages_RentUserId",
                table: "TblUnitDamages");

            migrationBuilder.DropColumn(
                name: "RentUserId",
                table: "TblUnitDamages");
        }
    }
}
