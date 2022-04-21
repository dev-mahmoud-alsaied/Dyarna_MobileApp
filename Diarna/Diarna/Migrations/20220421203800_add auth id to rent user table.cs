using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addauthidtorentusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "auth_id",
                table: "tbl_rentUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_rentUsers_AuthId",
                table: "tbl_rentUsers",
                column: "auth_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_rentUsers_tbl_authorization_AuthId",
                table: "tbl_rentUsers",
                column: "auth_id",
                principalTable: "tbl_authorization",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_rentUsers_tbl_authorization_AuthId",
                table: "tbl_rentUsers");

            migrationBuilder.DropIndex(
                name: "IX_tbl_rentUsers_AuthId",
                table: "tbl_rentUsers");

            migrationBuilder.DropColumn(
                name: "auht_id",
                table: "tbl_rentUsers");
        }
    }
}
