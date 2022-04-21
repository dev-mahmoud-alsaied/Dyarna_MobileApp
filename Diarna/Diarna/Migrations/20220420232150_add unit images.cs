using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addunitimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUnitImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TblUnitId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUnitImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUnitImages_tbl_units_TblUnitId",
                        column: x => x.TblUnitId,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblUnitImages_TblUnitId",
                table: "TblUnitImages",
                column: "TblUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblUnitImages");
        }
    }
}
