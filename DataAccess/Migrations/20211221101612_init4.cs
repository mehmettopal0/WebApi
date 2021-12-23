using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplyCompanyAndAreas",
                columns: table => new
                {
                    SupplyCompanyAndAreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyCompanyAndAreas");
        }
    }
}
