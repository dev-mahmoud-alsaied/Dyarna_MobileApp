using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addBuildingimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblBuildingImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TblBuildingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBuildingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBuildingImages_tbl_building_TblBuildingId",
                        column: x => x.TblBuildingId,
                        principalTable: "tbl_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBuildingImages_TblBuildingId",
                table: "TblBuildingImages",
                column: "TblBuildingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBuildingImages");
        }
    }
}
