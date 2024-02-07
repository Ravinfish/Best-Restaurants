using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestRestaurants.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Type" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Brunch" },
                    { 3, "Lunch" },
                    { 4, "Happy Hour" },
                    { 5, "Dinner" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "ServiceId",
                keyValue: 5);
        }
    }
}
