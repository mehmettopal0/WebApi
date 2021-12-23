using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentAreas_Areas_AreaId",
                table: "ContentAreas");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "ContentAreas",
                newName: "CityAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAreas_CityAreas_CityAreaId",
                table: "ContentAreas",
                column: "CityAreaId",
                principalTable: "CityAreas",
                principalColumn: "CityAreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContentAreas_CityAreas_CityAreaId",
                table: "ContentAreas");

            migrationBuilder.RenameColumn(
                name: "CityAreaId",
                table: "ContentAreas",
                newName: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContentAreas_Areas_AreaId",
                table: "ContentAreas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
