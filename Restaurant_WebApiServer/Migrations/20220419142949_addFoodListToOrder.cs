using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_WebApiServer.Migrations
{
    public partial class addFoodListToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_OrderId",
                table: "Foods",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Orders_OrderId",
                table: "Foods",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Orders_OrderId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_OrderId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Foods");
        }
    }
}
