using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartureCityId",
                table: "Expeditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArrivalCityId",
                table: "Expeditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExpeditionId",
                table: "Reservations",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_ArrivalCityId",
                table: "Expeditions",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_BusId",
                table: "Expeditions",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Expeditions_DepartureCityId",
                table: "Expeditions",
                column: "DepartureCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Buses_BusId",
                table: "Expeditions",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Cities_ArrivalCityId",
                table: "Expeditions",
                column: "ArrivalCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expeditions_Cities_DepartureCityId",
                table: "Expeditions",
                column: "DepartureCityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Expeditions_ExpeditionId",
                table: "Reservations",
                column: "ExpeditionId",
                principalTable: "Expeditions",
                principalColumn: "ExpeditionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Buses_BusId",
                table: "Expeditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Cities_ArrivalCityId",
                table: "Expeditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Expeditions_Cities_DepartureCityId",
                table: "Expeditions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Expeditions_ExpeditionId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ExpeditionId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_ArrivalCityId",
                table: "Expeditions");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_BusId",
                table: "Expeditions");

            migrationBuilder.DropIndex(
                name: "IX_Expeditions_DepartureCityId",
                table: "Expeditions");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureCityId",
                table: "Expeditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArrivalCityId",
                table: "Expeditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
