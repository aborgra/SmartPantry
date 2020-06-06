using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartPantry.Migrations
{
    public partial class UpdatedFavRecipeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "FavoriteRecipes");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "FavoriteRecipes");

            migrationBuilder.DropColumn(
                name: "Nutrients",
                table: "FavoriteRecipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20f594c3-043e-4dd7-8efe-755a64ce44f7", "AQAAAAEAACcQAAAAEJb/aXwLukYleI6CMGPcVxhn68xCxJH2VbO/FSZGJI+Ac2NRoORcdzn84k0cTZhbcQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Calories",
                table: "FavoriteRecipes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "FavoriteRecipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nutrients",
                table: "FavoriteRecipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32ec546a-ec95-476d-a021-9ce11d1a454a", "AQAAAAEAACcQAAAAEAXzihic/Y1xC+Hmew3IqAREYy7T76wqSOTmL7lH2YwpsOPg3MBnqXjUnUykQ88qAA==" });
        }
    }
}
