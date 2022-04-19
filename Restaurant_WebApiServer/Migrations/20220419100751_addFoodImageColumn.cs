using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_WebApiServer.Migrations
{
    public partial class addFoodImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");
        }
    }
}
