using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class AddQuantityUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityUnitId",
                table: "Foods",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateTable(
                name: "QuantityUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityUnits", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e92686d-3ddd-4a21-bf25-d0cdd06fa678", "AQAAAAEAACcQAAAAEFyqoFtnuZjvIjxCSw7cG31T3vrH+Maxk6gna9VRJviNRibEwv5D7xfBUYWz49cvHw==" });

            migrationBuilder.InsertData(
                table: "QuantityUnits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "gram" },
                    { 2, "cup" },
                    { 3, "gallon" },
                    { 4, "lb" },
                    { 5, "oz" },
                    { 6, "package" },
                    { 7, "pint" },
                    { 8, "other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_QuantityUnitId",
                table: "Foods",
                column: "QuantityUnitId");

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

            migrationBuilder.DropTable(
                name: "QuantityUnits");

            migrationBuilder.DropIndex(
                name: "IX_Foods_QuantityUnitId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "QuantityUnitId",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7413db42-7be2-4270-990e-f20b65cf140f", "AQAAAAEAACcQAAAAEKY/j8eM+i0hes0IVYTKFFWCkK5SMOItQGfjy4ihk/dIM3ER7NkgrQYLQrAdHdTTQw==" });
        }
    }
}
