using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSharing.Migrations.CarSharingCostDb
{
    public partial class CarAndConsumptionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumption_Car_CarId",
                table: "Consumption");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Consumption",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumption_Car_CarId",
                table: "Consumption",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumption_Car_CarId",
                table: "Consumption");

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Consumption",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Consumption_Car_CarId",
                table: "Consumption",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
