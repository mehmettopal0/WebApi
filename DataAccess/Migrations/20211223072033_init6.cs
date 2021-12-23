using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_SupplyCompanyAndAreas_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies");

            migrationBuilder.DropTable(
                name: "SupplyCompanyAndAreas");

            migrationBuilder.RenameColumn(
                name: "SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplies_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                newName: "IX_ProductSupplies_CompanyId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_Companies_CompanyId",
                table: "ProductSupplies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_ProductSupplies_ProductSupplyId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSupplies_Companies_CompanyId",
                table: "ProductSupplies");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ProductSupplyId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ProductSupplyId",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ProductSupplies",
                newName: "SupplySupplyCompanyAndAreaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductSupplies_CompanyId",
                table: "ProductSupplies",
                newName: "IX_ProductSupplies_SupplySupplyCompanyAndAreaId");

            migrationBuilder.CreateTable(
                name: "SupplyCompanyAndAreas",
                columns: table => new
                {
                    SupplyCompanyAndAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyCompanyAndAreas", x => x.SupplyCompanyAndAreaId);
                    table.ForeignKey(
                        name: "FK_SupplyCompanyAndAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyCompanyAndAreas_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplyCompanyAndAreas_AreaId",
                table: "SupplyCompanyAndAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyCompanyAndAreas_CompanyId",
                table: "SupplyCompanyAndAreas",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSupplies_SupplyCompanyAndAreas_SupplySupplyCompanyAndAreaId",
                table: "ProductSupplies",
                column: "SupplySupplyCompanyAndAreaId",
                principalTable: "SupplyCompanyAndAreas",
                principalColumn: "SupplyCompanyAndAreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
