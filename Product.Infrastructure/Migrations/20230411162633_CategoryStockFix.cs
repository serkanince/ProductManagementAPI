using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CategoryStockFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "MinimumStock" },
                values: new object[] { new DateTime(2023, 4, 11, 19, 26, 33, 586, DateTimeKind.Utc).AddTicks(9955), 50 });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "MinimumStock" },
                values: new object[] { new DateTime(2023, 4, 11, 19, 26, 33, 586, DateTimeKind.Utc).AddTicks(9997), 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 11, 19, 26, 33, 587, DateTimeKind.Utc).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 11, 19, 26, 33, 587, DateTimeKind.Utc).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 11, 19, 26, 33, 587, DateTimeKind.Utc).AddTicks(16));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 11, 19, 26, 33, 587, DateTimeKind.Utc).AddTicks(18));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CreateDate", "MinimumStock" },
                values: new object[] { new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5406), 200 });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CreateDate", "MinimumStock" },
                values: new object[] { new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5464), 150 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5495));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2023, 4, 10, 16, 48, 59, 166, DateTimeKind.Utc).AddTicks(5497));
        }
    }
}
