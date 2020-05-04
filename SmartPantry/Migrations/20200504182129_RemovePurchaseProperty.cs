using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class RemovePurchaseProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d585d268-0fce-4bd2-978e-eb3cbea991a2", "AQAAAAEAACcQAAAAEKz1LHPCXnkEu3fb65qBFoxeI1bbQC61dR5KsJK3DPo7SSOm8vFIaiXgUnz1CYCneQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "Foods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b706f6-c5e4-4fea-8e26-bc96c082bd2a", "AQAAAAEAACcQAAAAEOklf4wfLLGN4F0+nwrnif6hJIUFxx0oEvVTCsGaXlYovWYqOs8E7+VNKUYe7hY84A==" });
        }
    }
}
