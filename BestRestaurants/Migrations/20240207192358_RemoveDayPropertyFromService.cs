using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestRestaurants.Migrations
{
    public partial class RemoveDayPropertyFromService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Services");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Services",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
