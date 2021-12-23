using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyAreas");

            migrationBuilder.CreateTable(
                name: "ContentAreas",
                columns: table => new
                {
                    ProductContentId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAreas", x => new { x.AreaId, x.ProductContentId });
                    table.ForeignKey(
                        name: "FK_ContentAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContentAreas_ProductContents_ProductContentId",
                        column: x => x.ProductContentId,
                        principalTable: "ProductContents",
                        principalColumn: "ProductContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentAreas_ProductContentId",
                table: "ContentAreas",
                column: "ProductContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentAreas");

            migrationBuilder.CreateTable(
                name: "SupplyAreas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    ProductSupplyId = table.Column<int>(type: "int", nullable: false)
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
    }
}
