using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "ParentEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                newName: "IX_Employees_ParentEmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ParentEmployeeId",
                table: "Employees",
                column: "ParentEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ParentEmployeeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ParentEmployeeId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ParentEmployeeId",
                table: "Employees",
                newName: "IX_Employees_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
