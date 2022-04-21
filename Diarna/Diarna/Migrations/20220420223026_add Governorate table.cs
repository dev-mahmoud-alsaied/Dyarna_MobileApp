using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diarna.Migrations
{
    public partial class addGovernoratetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_authorization",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    screenName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_authorization", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_itemType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_itemType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rentUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rentUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_reservationDate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reservationDate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_systemUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    superAdmin = table.Column<bool>(type: "bit", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_systemUsers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tenders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    tatalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tenders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TblGovernorates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGovernorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_userShares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    auth_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_userShares", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_userShares_tbl_authorization",
                        column: x => x.auth_id,
                        principalTable: "tbl_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    generalExpenses = table.Column<bool>(type: "bit", nullable: false),
                    itemtype_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_item_tbl_itemType",
                        column: x => x.itemtype_id,
                        principalTable: "tbl_itemType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_systemUser_authorization",
                columns: table => new
                {
                    sysUser_id = table.Column<int>(type: "int", nullable: false),
                    auth_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_systemUser_authorization", x => new { x.sysUser_id, x.auth_id });
                    table.ForeignKey(
                        name: "FK_tbl_systemUser_authorization_tbl_authorization",
                        column: x => x.auth_id,
                        principalTable: "tbl_authorization",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_systemUser_authorization_tbl_systemUsers",
                        column: x => x.sysUser_id,
                        principalTable: "tbl_systemUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_village",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tblGovernorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_village", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_village_TblGovernorates_tblGovernorateId",
                        column: x => x.tblGovernorateId,
                        principalTable: "TblGovernorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_shares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userShares_id = table.Column<int>(type: "int", nullable: true),
                    startDate = table.Column<DateTime>(type: "date", nullable: true),
                    userCash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    percent = table.Column<double>(type: "float", nullable: true),
                    managePercent = table.Column<double>(type: "float", nullable: true),
                    userMinProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    additionProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    endDate = table.Column<DateTime>(type: "date", nullable: true),
                    shareType = table.Column<byte>(type: "tinyint", nullable: true),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_shares", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_shares_tbl_userShares1",
                        column: x => x.userShares_id,
                        principalTable: "tbl_userShares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contractingExpnses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<double>(type: "float", nullable: true),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tender_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contractingExpnses", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_contractingExpnses_tbl_item1",
                        column: x => x.item_id,
                        principalTable: "tbl_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_contractingExpnses_tbl_tenders1",
                        column: x => x.tender_id,
                        principalTable: "tbl_tenders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_contractingImports",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<double>(type: "float", nullable: true),
                    unitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tender_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contractingImports", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_contractingImports_tbl_item1",
                        column: x => x.item_id,
                        principalTable: "tbl_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_contractingImports_tbl_tenders1",
                        column: x => x.tender_id,
                        principalTable: "tbl_tenders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_building",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    village_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_building", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_building_tbl_village1",
                        column: x => x.village_id,
                        principalTable: "tbl_village",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_tender_Shares",
                columns: table => new
                {
                    tender_id = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    shares_id = table.Column<int>(type: "int", nullable: false),
                    sharePercentage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_tender_userShares", x => new { x.tender_id, x.year, x.shares_id });
                    table.ForeignKey(
                        name: "FK_tbl_tender_userShares_tbl_shares1",
                        column: x => x.shares_id,
                        principalTable: "tbl_shares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_tender_userShares_tbl_tenders1",
                        column: x => x.tender_id,
                        principalTable: "tbl_tenders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    building_id = table.Column<int>(type: "int", nullable: true),
                    systemOwned = table.Column<bool>(type: "bit", nullable: true),
                    minInsuranceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    minDepositValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isValid = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_units", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_units_tbl_building1",
                        column: x => x.building_id,
                        principalTable: "tbl_building",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_monthlyFiltring",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    value = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_monthlyFiltring", x => new { x.unit_id, x.date });
                    table.ForeignKey(
                        name: "FK_tbl_monthlyFiltring_tbl_units1",
                        column: x => x.unit_id,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rentedUnits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rentStartDate = table.Column<DateTime>(type: "date", nullable: true),
                    rentEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    deliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unit_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rentedUnits", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_RentedUnits_tbl_units",
                        column: x => x.unit_id,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_rentExpenses",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    itemValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Shares_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_rentExpenses", x => new { x.item_id, x.date, x.unit_id });
                    table.ForeignKey(
                        name: "FK_tbl_rentExpenses_tbl_item1",
                        column: x => x.item_id,
                        principalTable: "tbl_item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_rentExpenses_tbl_shares1",
                        column: x => x.Shares_id,
                        principalTable: "tbl_shares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_rentExpenses_tbl_units",
                        column: x => x.unit_id,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_reservation",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    date_id = table.Column<int>(type: "int", nullable: false),
                    rentUser_id = table.Column<int>(type: "int", nullable: true),
                    insuranceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    totalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    depositValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    confirmReservation = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reservation", x => new { x.unit_id, x.date_id });
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_RentUsers",
                        column: x => x.rentUser_id,
                        principalTable: "tbl_rentUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_reservationDate1",
                        column: x => x.date_id,
                        principalTable: "tbl_reservationDate",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_units1",
                        column: x => x.unit_id,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_units_Shares",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    shares_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_userShares_units", x => new { x.unit_id, x.year, x.shares_id });
                    table.ForeignKey(
                        name: "FK_tbl_userShares_units_tbl_shares1",
                        column: x => x.shares_id,
                        principalTable: "tbl_shares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_userShares_units_tbl_units1",
                        column: x => x.unit_id,
                        principalTable: "tbl_units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_building_village_id",
                table: "tbl_building",
                column: "village_id");

            migrationBuilder.CreateIndex(
                name: "uniqueNameForBuilding",
                table: "tbl_building",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_contractingExpnses_item_id",
                table: "tbl_contractingExpnses",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_contractingExpnses_tender_id",
                table: "tbl_contractingExpnses",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_contractingImports_item_id",
                table: "tbl_contractingImports",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_contractingImports_tender_id",
                table: "tbl_contractingImports",
                column: "tender_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_item_itemtype_id",
                table: "tbl_item",
                column: "itemtype_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_rentedUnits_unit_id",
                table: "tbl_rentedUnits",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_rentExpenses_Shares_id",
                table: "tbl_rentExpenses",
                column: "Shares_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_rentExpenses_unit_id",
                table: "tbl_rentExpenses",
                column: "unit_id");

            migrationBuilder.CreateIndex(
                name: "uniqueMobile",
                table: "tbl_rentUsers",
                column: "mobile",
                unique: true,
                filter: "[mobile] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_date_id",
                table: "tbl_reservation",
                column: "date_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_rentUser_id",
                table: "tbl_reservation",
                column: "rentUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shares_userShares_id",
                table: "tbl_shares",
                column: "userShares_id");

            migrationBuilder.CreateIndex(
                name: "UniqueSharesName",
                table: "tbl_shares",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_systemUser_authorization_auth_id",
                table: "tbl_systemUser_authorization",
                column: "auth_id");

            migrationBuilder.CreateIndex(
                name: "uniqueSysUserMobile",
                table: "tbl_systemUsers",
                column: "mobile",
                unique: true,
                filter: "[mobile] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_tender_Shares_shares_id",
                table: "tbl_tender_Shares",
                column: "shares_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_units_building_id",
                table: "tbl_units",
                column: "building_id");

            migrationBuilder.CreateIndex(
                name: "uniqueNameForUnits",
                table: "tbl_units",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_units_Shares_shares_id",
                table: "tbl_units_Shares",
                column: "shares_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_userShares_auth_id",
                table: "tbl_userShares",
                column: "auth_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_village_tblGovernorateId",
                table: "tbl_village",
                column: "tblGovernorateId");

            migrationBuilder.CreateIndex(
                name: "uniqueNameForVillage",
                table: "tbl_village",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_contractingExpnses");

            migrationBuilder.DropTable(
                name: "tbl_contractingImports");

            migrationBuilder.DropTable(
                name: "tbl_monthlyFiltring");

            migrationBuilder.DropTable(
                name: "tbl_rentedUnits");

            migrationBuilder.DropTable(
                name: "tbl_rentExpenses");

            migrationBuilder.DropTable(
                name: "tbl_reservation");

            migrationBuilder.DropTable(
                name: "tbl_systemUser_authorization");

            migrationBuilder.DropTable(
                name: "tbl_tender_Shares");

            migrationBuilder.DropTable(
                name: "tbl_units_Shares");

            migrationBuilder.DropTable(
                name: "tbl_item");

            migrationBuilder.DropTable(
                name: "tbl_rentUsers");

            migrationBuilder.DropTable(
                name: "tbl_reservationDate");

            migrationBuilder.DropTable(
                name: "tbl_systemUsers");

            migrationBuilder.DropTable(
                name: "tbl_tenders");

            migrationBuilder.DropTable(
                name: "tbl_shares");

            migrationBuilder.DropTable(
                name: "tbl_units");

            migrationBuilder.DropTable(
                name: "tbl_itemType");

            migrationBuilder.DropTable(
                name: "tbl_userShares");

            migrationBuilder.DropTable(
                name: "tbl_building");

            migrationBuilder.DropTable(
                name: "tbl_authorization");

            migrationBuilder.DropTable(
                name: "tbl_village");

            migrationBuilder.DropTable(
                name: "TblGovernorates");
        }
    }
}
