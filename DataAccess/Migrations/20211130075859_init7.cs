using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSupervisor",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SupervisorNo",
                table: "Employees",
                newName: "ParentId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Employees",
                newName: "SupervisorNo");

            migrationBuilder.AddColumn<bool>(
                name: "IsSupervisor",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
