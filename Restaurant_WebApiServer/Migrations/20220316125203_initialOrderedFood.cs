using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_WebApiServer.Migrations
{
    public partial class initialOrderedFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OrderedFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedFoods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedFoods");

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
    }
}
