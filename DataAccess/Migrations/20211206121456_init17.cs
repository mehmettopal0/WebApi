using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Parent_ParentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Parents",
                newName: "ParenId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "ParenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Parents_ParentId",
                table: "Employees",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "ParenId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Parents_ParentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.RenameColumn(
                name: "ParenId",
                table: "Parent",
                newName: "ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Parent_ParentId",
                table: "Employees",
                column: "ParentId",
                principalTable: "Parent",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
