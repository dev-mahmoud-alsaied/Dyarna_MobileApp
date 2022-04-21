using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class unitdamagetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblUnitDamages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUnitDamages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUnitDamages_tbl_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "tbl_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUnitDamages_tbl_units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblUnitDamages_ItemId",
                table: "TblUnitDamages",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUnitDamages_UnitId",
                table: "TblUnitDamages",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblUnitDamages");
        }
    }
}
