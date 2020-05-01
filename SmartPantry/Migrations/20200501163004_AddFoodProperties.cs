using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class AddFoodProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17a38f97-c07a-4230-8e96-3f6b085b01d4", "AQAAAAEAACcQAAAAEJYOrbaNYCdVldyKdZ3SskTLEN8giRb2wJqNdOnsH9U5fjT36LvwVf22tLSzq/2Hkw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PantryId",
                table: "Foods",
                column: "PantryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Pantries_PantryId",
                table: "Foods",
                column: "PantryId",
                principalTable: "Pantries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Pantries_PantryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PantryId",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bf856b0-ce71-4907-8bd4-0c7c07dfbca1", "AQAAAAEAACcQAAAAEAFrT1MkRzaufmi2Fj6pWpGambC3kLKOxGhkxtFZLspEFgtH6W0eaxNffC6mq9/lRA==" });
        }
    }
}
