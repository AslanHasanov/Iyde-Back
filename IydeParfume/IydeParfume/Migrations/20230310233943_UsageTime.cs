using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IydeParfume.Migrations
{
    /// <inheritdoc />
    public partial class UsageTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsageTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductUsageTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UsageTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUsageTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductUsageTime_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUsageTime_UsageTimes_UsageTimeId",
                        column: x => x.UsageTimeId,
                        principalTable: "UsageTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUsageTime_ProductId",
                table: "ProductUsageTime",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUsageTime_UsageTimeId",
                table: "ProductUsageTime",
                column: "UsageTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUsageTime");

            migrationBuilder.DropTable(
                name: "UsageTimes");
        }
    }
}
