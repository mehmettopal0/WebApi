using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Parents");

            migrationBuilder.RenameColumn(
                name: "ParenId",
                table: "Parents",
                newName: "PerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PerId",
                table: "Parents",
                newName: "ParenId");

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Parents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
