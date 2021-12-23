using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentAreas");

            migrationBuilder.CreateTable(
                name: "ProductAreas",
                columns: table => new
                {
                    ProductContentId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAreas", x => new { x.AreaId, x.ProductContentId });
                    table.ForeignKey(
                        name: "FK_ProductAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAreas_ProductContents_ProductContentId",
                        column: x => x.ProductContentId,
                        principalTable: "ProductContents",
                        principalColumn: "ProductContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCities",
                columns: table => new
                {
                    ProductContentId = table.Column<int>(type: "int", nullable: false),
                    CityAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCities", x => new { x.CityAreaId, x.ProductContentId });
                    table.ForeignKey(
                        name: "FK_ProductCities_CityAreas_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "CityAreas",
                        principalColumn: "CityAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCities_ProductContents_ProductContentId",
                        column: x => x.ProductContentId,
                        principalTable: "ProductContents",
                        principalColumn: "ProductContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAreas_ProductContentId",
                table: "ProductAreas",
                column: "ProductContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCities_ProductContentId",
                table: "ProductCities",
                column: "ProductContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAreas");

            migrationBuilder.DropTable(
                name: "ProductCities");

            migrationBuilder.CreateTable(
                name: "ContentAreas",
                columns: table => new
                {
                    CityAreaId = table.Column<int>(type: "int", nullable: false),
                    ProductContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAreas", x => new { x.CityAreaId, x.ProductContentId });
                    table.ForeignKey(
                        name: "FK_ContentAreas_CityAreas_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "CityAreas",
                        principalColumn: "CityAreaId",
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
    }
}
