using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CityAreas_Areas_AreaId",
                table: "CityAreas");

            migrationBuilder.DropIndex(
                name: "IX_CityAreas_AreaId",
                table: "CityAreas");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "CityAreas");

            migrationBuilder.AddColumn<int>(
                name: "CityAreaId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityAreaId",
                table: "Areas",
                column: "CityAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_CityAreas_CityAreaId",
                table: "Areas",
                column: "CityAreaId",
                principalTable: "CityAreas",
                principalColumn: "CityAreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_CityAreas_CityAreaId",
                table: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CityAreaId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CityAreaId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "CityAreas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CityAreas_AreaId",
                table: "CityAreas",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CityAreas_Areas_AreaId",
                table: "CityAreas",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
