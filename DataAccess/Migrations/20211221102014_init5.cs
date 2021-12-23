using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplies_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                column: "SupplySupplyCompanyAndAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_SupplyCompanyAndAreas_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                column: "SupplySupplyCompanyAndAreaId",
                principalTable: "SupplyCompanyAndAreas",
                principalColumn: "SupplyCompanyAndAreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_SupplyCompanyAndAreas_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies");

            migrationBuilder.DropIndex(
                name: "IX_ProductSupplies_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies");

            migrationBuilder.DropColumn(
                name: "SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies");
        }
    }
}
