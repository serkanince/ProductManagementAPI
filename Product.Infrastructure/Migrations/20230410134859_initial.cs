using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MinimumStock = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CreateDate", "MinimumStock", "ModifyDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5406), 200, null, "Mobile Phone" },
                    { 2, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5464), 150, null, "PC" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreateDate", "Description", "ModifyDate", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5490), "Best mobile phone ever, buy it !", null, 0m, 100, "iPhone 14" },
                    { 2, 1, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5493), "Best mobile phone ever, buy it !", null, 0m, 100, "iPhone 14 PRO" },
                    { 3, 2, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5495), "Best personel computer ever, buy it !", null, 0m, 100, "Mac M1 128GB" },
                    { 4, 2, new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5497), "Best personel computer ever, buy it !", null, 0m, 100, "Mac M2 256GB" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
