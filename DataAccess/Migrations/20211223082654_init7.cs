using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_ProductSupplies_ProductSupplyId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ProductSupplyId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ProductSupplyId",
                table: "Areas");

            migrationBuilder.CreateTable(
                name: "SupplyAreas",
                columns: table => new
                {
                    ProductSupplyId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyAreas", x => new { x.AreaId, x.ProductSupplyId });
                    table.ForeignKey(
                        name: "FK_SupplyAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyAreas_ProductSupplies_ProductSupplyId",
                        column: x => x.ProductSupplyId,
                        principalTable: "ProductSupplies",
                        principalColumn: "ProductSupplyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplyAreas_ProductSupplyId",
                table: "SupplyAreas",
                column: "ProductSupplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyAreas");

            migrationBuilder.AddColumn<int>(
                name: "ProductSupplyId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ProductSupplyId",
                table: "Areas",
                column: "ProductSupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_ProductSupplies_ProductSupplyId",
                table: "Areas",
                column: "ProductSupplyId",
                principalTable: "ProductSupplies",
                principalColumn: "ProductSupplyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
