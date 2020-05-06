using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class RemoveFoodPurchaseBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1bf7e04-a17f-4931-b536-f4cc86825519", "AQAAAAEAACcQAAAAEKJSGFQHaViNhL6YYKcyHoBu8itGEqaEGQ9nkuj8AHgtsVBIeZM155JOb7Q0xw2aKw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d585d268-0fce-4bd2-978e-eb3cbea991a2", "AQAAAAEAACcQAAAAEKz1LHPCXnkEu3fb65qBFoxeI1bbQC61dR5KsJK3DPo7SSOm8vFIaiXgUnz1CYCneQ==" });
        }
    }
}
