using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_ProductComs_ProductComId",
                table: "ProductSupplies");

            migrationBuilder.RenameColumn(
                name: "ProductComId",
                table: "ProductSupplies",
                newName: "ProductContentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplies_ProductComId",
                table: "ProductSupplies",
                newName: "IX_ProductSupplies_ProductContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_ProductContents_ProductContentId",
                table: "ProductSupplies",
                column: "ProductContentId",
                principalTable: "ProductContents",
                principalColumn: "ProductContentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_ProductContents_ProductContentId",
                table: "ProductSupplies");

            migrationBuilder.RenameColumn(
                name: "ProductContentId",
                table: "ProductSupplies",
                newName: "ProductComId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplies_ProductContentId",
                table: "ProductSupplies",
                newName: "IX_ProductSupplies_ProductComId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_ProductComs_ProductComId",
                table: "ProductSupplies",
                column: "ProductComId",
                principalTable: "ProductComs",
                principalColumn: "ProductComId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
