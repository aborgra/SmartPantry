using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class QuanUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_QuantityUnits_QuantityUnitId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityUnitId",
                table: "Foods",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a10dc136-1cec-46d4-ab6a-a3c362ae9a0a", "AQAAAAEAACcQAAAAEM5KACPrhx5zrPP7x0thY19JE67QI/KAodNPjFU0eGvAbqwpf0m8iRqVAFXMhi0k2w==" });

            migrationBuilder.UpdateData(
                table: "QuantityUnits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "grams");

            migrationBuilder.UpdateData(
                table: "QuantityUnits",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "lbs");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_QuantityUnits_QuantityUnitId",
                table: "Foods",
                column: "QuantityUnitId",
                principalTable: "QuantityUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_QuantityUnits_QuantityUnitId",
                table: "Foods");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityUnitId",
                table: "Foods",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e92686d-3ddd-4a21-bf25-d0cdd06fa678", "AQAAAAEAACcQAAAAEFyqoFtnuZjvIjxCSw7cG31T3vrH+Maxk6gna9VRJviNRibEwv5D7xfBUYWz49cvHw==" });

            migrationBuilder.UpdateData(
                table: "QuantityUnits",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "gram");

            migrationBuilder.UpdateData(
                table: "QuantityUnits",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "lb");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_QuantityUnits_QuantityUnitId",
                table: "Foods",
                column: "QuantityUnitId",
                principalTable: "QuantityUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
