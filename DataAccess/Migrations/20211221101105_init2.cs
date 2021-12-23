using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_Companies_CompanyId",
                table: "ProductSupplies");

            migrationBuilder.DropIndex(
                name: "IX_ProductSupplies_CompanyId",
                table: "ProductSupplies");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductSupplies");

            migrationBuilder.AddColumn<int>(
                name: "ProductSupplyId",
                table: "Companies",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ProductSupplies_ProductSupplyId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ProductSupplyId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProductSupplyId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ProductSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplies_CompanyId",
                table: "ProductSupplies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_Companies_CompanyId",
                table: "ProductSupplies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
