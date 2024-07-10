using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ItemManagment.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "Description", "Internal_code", "Serial_number" },
                values: new object[,]
                {
                    { 1, "Lenovo H/Y i5", "E/B/0000", "AASSDD8875" },
                    { 2, "Lenovo H/Y i5", "E/B/0000", "AASSDD8975" },
                    { 3, "Lenovo Screen 24\"", "E/B/1111", "AASSDD2222" },
                    { 4, "Xiaomi RedMi Note 8", "E/B/1110", "AASSDD0000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
