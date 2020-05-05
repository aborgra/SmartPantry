using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class PurchasedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b706f6-c5e4-4fea-8e26-bc96c082bd2a", "AQAAAAEAACcQAAAAEOklf4wfLLGN4F0+nwrnif6hJIUFxx0oEvVTCsGaXlYovWYqOs8E7+VNKUYe7hY84A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4718e5d0-e6f5-4a6f-8696-52eb4979c3cb", "AQAAAAEAACcQAAAAEL1QRnWbwL2ZS5OQO1pxp3xKw34xf/w0XmEgBuoitRgtEBAxy26wprYZ7HQfk8Y0Eg==" });
        }
    }
}
