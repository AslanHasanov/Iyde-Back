using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IydeParfume.Migrations
{
    /// <inheritdoc />
    public partial class ImageToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageInFileSystem",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "basket-products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_basket-products_SizeId",
                table: "basket-products",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_basket-products_Sizes_SizeId",
                table: "basket-products",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_basket-products_Sizes_SizeId",
                table: "basket-products");

            migrationBuilder.DropIndex(
                name: "IX_basket-products_SizeId",
                table: "basket-products");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "ImageInFileSystem",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "basket-products");
        }
    }
}
