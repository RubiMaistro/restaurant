using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Restaurant_WebApiServer.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotosToFoodModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderedFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Bytes = table.Column<byte[]>(type: "longblob", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    FileExtension = table.Column<string>(type: "longtext", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Foods_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductId",
                table: "Photos",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderedFoods");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                type: "longtext",
                nullable: false);
        }
    }
}
