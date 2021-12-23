using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProductSupplies_ProductSupplyId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_Areas_AreaId",
                table: "ProductSupplies");

            migrationBuilder.DropIndex(
                name: "IX_ProductSupplies_AreaId",
                table: "ProductSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ProductSupplyId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "ProductSupplies");

            migrationBuilder.DropColumn(
                name: "ProductSupplyId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "ProductSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductSupplyId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplies_AreaId",
                table: "ProductSupplies",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProductSupplyId",
                table: "Companies",
                column: "ProductSupplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ProductSupplies_ProductSupplyId",
                table: "Companies",
                column: "ProductSupplyId",
                principalTable: "ProductSupplies",
                principalColumn: "ProductSupplyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_Areas_AreaId",
                table: "ProductSupplies",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
