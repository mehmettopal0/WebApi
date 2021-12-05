using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ParentEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ParentEmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ParentEmployeeId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ParentId",
                table: "Employees",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ParentId",
                table: "Employees",
                column: "ParentId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ParentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ParentId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "ParentEmployeeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ParentEmployeeId",
                table: "Employees",
                column: "ParentEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ParentEmployeeId",
                table: "Employees",
                column: "ParentEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
