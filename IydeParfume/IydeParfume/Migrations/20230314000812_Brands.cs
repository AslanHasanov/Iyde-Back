using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IydeParfume.Migrations
{
    /// <inheritdoc />
    public partial class Brands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Groups_GroupId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Products_ProductId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUsageTime_Products_ProductId",
                table: "ProductUsageTime");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUsageTime_UsageTimes_UsageTimeId",
                table: "ProductUsageTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUsageTime",
                table: "ProductUsageTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGroup",
                table: "ProductGroup");

            migrationBuilder.RenameTable(
                name: "ProductUsageTime",
                newName: "ProductUsageTimes");

            migrationBuilder.RenameTable(
                name: "ProductGroup",
                newName: "ProductGroups");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUsageTime_UsageTimeId",
                table: "ProductUsageTimes",
                newName: "IX_ProductUsageTimes_UsageTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUsageTime_ProductId",
                table: "ProductUsageTimes",
                newName: "IX_ProductUsageTimes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroup_ProductId",
                table: "ProductGroups",
                newName: "IX_ProductGroups_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroup_GroupId",
                table: "ProductGroups",
                newName: "IX_ProductGroups_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUsageTimes",
                table: "ProductUsageTimes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductBrands_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_BrandId",
                table: "ProductBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_ProductId",
                table: "ProductBrands",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_Groups_GroupId",
                table: "ProductGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_Products_ProductId",
                table: "ProductGroups",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUsageTimes_Products_ProductId",
                table: "ProductUsageTimes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUsageTimes_UsageTimes_UsageTimeId",
                table: "ProductUsageTimes",
                column: "UsageTimeId",
                principalTable: "UsageTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_Groups_GroupId",
                table: "ProductGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_Products_ProductId",
                table: "ProductGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUsageTimes_Products_ProductId",
                table: "ProductUsageTimes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUsageTimes_UsageTimes_UsageTimeId",
                table: "ProductUsageTimes");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUsageTimes",
                table: "ProductUsageTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductGroups",
                table: "ProductGroups");

            migrationBuilder.RenameTable(
                name: "ProductUsageTimes",
                newName: "ProductUsageTime");

            migrationBuilder.RenameTable(
                name: "ProductGroups",
                newName: "ProductGroup");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUsageTimes_UsageTimeId",
                table: "ProductUsageTime",
                newName: "IX_ProductUsageTime_UsageTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUsageTimes_ProductId",
                table: "ProductUsageTime",
                newName: "IX_ProductUsageTime_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroups_ProductId",
                table: "ProductGroup",
                newName: "IX_ProductGroup_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroups_GroupId",
                table: "ProductGroup",
                newName: "IX_ProductGroup_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUsageTime",
                table: "ProductUsageTime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductGroup",
                table: "ProductGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Groups_GroupId",
                table: "ProductGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Products_ProductId",
                table: "ProductGroup",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUsageTime_Products_ProductId",
                table: "ProductUsageTime",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUsageTime_UsageTimes_UsageTimeId",
                table: "ProductUsageTime",
                column: "UsageTimeId",
                principalTable: "UsageTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
