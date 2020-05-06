using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class DialogBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7413db42-7be2-4270-990e-f20b65cf140f", "AQAAAAEAACcQAAAAEKY/j8eM+i0hes0IVYTKFFWCkK5SMOItQGfjy4ihk/dIM3ER7NkgrQYLQrAdHdTTQw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a1bf7e04-a17f-4931-b536-f4cc86825519", "AQAAAAEAACcQAAAAEKJSGFQHaViNhL6YYKcyHoBu8itGEqaEGQ9nkuj8AHgtsVBIeZM155JOb7Q0xw2aKw==" });
        }
    }
}
